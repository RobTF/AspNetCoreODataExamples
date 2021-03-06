﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataExample.Data.Repositories;
using ODataExampleCommon;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Routing.Attributes;

namespace ODataExample.Controllers
{
    public class AccountsController : ODataController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountsController(
            IAccountRepository accountRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IActionResult Get(ODataQueryOptions<Account> options)
        {
            var countOnly = options.Count?.Value == true && options.RawValues.Count == null;

            var query = _accountRepository.Get();
            var finalQuery = options.ApplyTo(query.ProjectTo<Account>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            return Ok(countOnly ? finalQuery.Count() : finalQuery);
        }

        public async Task<IActionResult> Get(Guid key, ODataQueryOptions<Account> options)
        {
            var query = _accountRepository.Get().Where(x => x.Id == key);

            var finalQuery = options.ApplyTo(query.ProjectTo<Account>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            var x = await finalQuery.ToArrayAsync();
            var item = x.FirstOrDefault(); // await finalQuery.FirstOrDefaultAsync();
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet]
        [ODataRoute("Accounts({key})/GetUsers()")]
        public IActionResult GetUsersInAccount(Guid key, ODataQueryOptions<User> options)
        {
            var query =
                from u in _userRepository.GetUsersByAccount(key)
                select u;

            var finalQuery = options.ApplyTo(query.ProjectTo<User>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            return Ok(finalQuery);
        }
    }
}
