using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataExample.Models;

namespace ODataExample.Data.EdmModels
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();
            
            builder.EntitySet<User>("Users");
            var accountEntitySet = builder.EntitySet<Account>("Accounts");

            accountEntitySet.EntityType.Function("GetUsers")
                .ReturnsCollectionFromEntitySet<User>("Users");

            return builder.GetEdmModel();
        }
    }
}
