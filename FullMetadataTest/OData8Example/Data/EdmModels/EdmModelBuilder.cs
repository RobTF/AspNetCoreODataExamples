using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataExampleCommon;

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
