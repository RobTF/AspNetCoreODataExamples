using System;
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

namespace ODataExample.Controllers
{
    public class UsersController : ODataController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IActionResult Get(ODataQueryOptions<User> options)
        {
            var groupName = User.Claims.First(c => c.Type == "api.group").Value;

            var countOnly = options.Count?.Value == true && options.RawValues.Count == null;

            var query = _userRepository.Get().Where(u => u.GroupName == groupName);
            var finalQuery = options.ApplyTo(query.ProjectTo<User>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            return Ok(countOnly ? finalQuery.Count() : finalQuery);
        }

        public async Task<IActionResult> Get(Guid key, ODataQueryOptions<User> options)
        {
            var groupName = User.Claims.First(c => c.Type == "api.group").Value;

            var query = _userRepository.Get().Where(x => x.Id == key && x.GroupName == groupName);

            var finalQuery = options.ApplyTo(query.ProjectTo<User>(_mapper.ConfigurationProvider)) as IQueryable<dynamic>;
            var x = await finalQuery.ToArrayAsync();
            var item = x.FirstOrDefault();
            return item == null ? NotFound() : Ok(item);
        }
    }
}
