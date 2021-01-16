using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataExample.Data.Repositories;
using ODataExample.Models;

namespace ODataExample.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountsController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(ODataQueryOptions<Account> options)
        {
            var query = _accountRepository.Get();
            var finalQuery = options.ApplyTo(query.ProjectTo<Account>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            var odata = HttpContext.ODataFeature();
            return Ok(new PageResult<dynamic>(finalQuery, odata.NextLink, odata.TotalCount));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, ODataQueryOptions<Account> options)
        {
            var query = _accountRepository.Get().Where(x => x.Id == id);
            var finalQuery = options.ApplyTo(query.ProjectTo<Account>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            var item = await finalQuery.FirstOrDefaultAsync();
            return (item == null) ? NotFound() : Ok(item);
        }
    }
}
