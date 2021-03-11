using AutoMapper;
using ODataExample.Data.EdmModels;
using ODataExampleCommon;

namespace ODataExample
{
    public class Mapper : AutoMapper.Mapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper"/> class.
        /// </summary>
        public Mapper()
            : base(new MapperConfiguration(c => c.AddProfile(new MapperProfile())))
        {
        }

        private class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<UserEdm, User>();
                CreateMap<AccountEdm, Account>();
            }
        }
    }
}
