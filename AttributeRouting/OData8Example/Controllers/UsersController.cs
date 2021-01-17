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
    /*[Route("api")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [Route("accounts/{accountId}/users")]
        public IActionResult GetByAccount(Guid accountId, ODataQueryOptions<User> options)
        {
            var groupName = User.Claims.First(c => c.Type == "api.group").Value;

            var query =
                from u in _userRepository.GetUsersByAccount(accountId)
                where u.GroupName == groupName
                select u;

            var finalQuery = options.ApplyTo(query.ProjectTo<User>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;

            var odata = HttpContext.ODataFeature();
            return Ok(new PageResult<dynamic>(finalQuery, odata.NextLink, odata.TotalCount));
        }

        [Route("accounts/{accountId}/users/{userId}")]
        public async Task<IActionResult> GetById(Guid accountId, Guid userId, ODataQueryOptions<User> options)
        {
            var groupName = User.Claims.First(c => c.Type == "api.group").Value;

            var query =
                from u in _userRepository.GetUsersByAccount(accountId)
                where u.GroupName == groupName && u.Id == userId
                select u;

            var finalQuery = options.ApplyTo(query.ProjectTo<User>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            var item = await finalQuery.FirstOrDefaultAsync();
            return (item == null) ? NotFound() : Ok(item);
        }
    }*/
}
