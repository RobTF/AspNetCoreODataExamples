using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ODataExample;

namespace OData8ExampleTests
{
    [TestClass]
    public class FullMetaDataTests
    {
        private WebApplicationFactory<Startup>? _factory;

        private WebApplicationFactory<Startup> Factory => _factory ?? throw new InvalidOperationException("Factory not ready.");

        [TestInitialize]
        public void Initialize()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _factory?.Dispose();
        }

        [TestMethod]
        public async Task Should_Return_Minimal_Metadata()
        {
            var client = Factory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=minimal");

            var resp = await client.GetAsync("accounts/1c82f39e-462e-4e76-ac84-7fb9ca4827b9/GetUsers()?$select=name");
            resp.EnsureSuccessStatusCode();

            var str = await resp.Content.ReadAsStringAsync();

            Assert.AreEqual(@"{""@odata.context"":""http://localhost/$metadata#Collection(ODataExample.Models.User)"",""value"":[{""name"":""User 4""},{""name"":""User 7""},{""name"":""User 8""}]}", str);
        }

        [TestMethod]
        public async Task Should_Return_Full_Metadata_For_Entity_Set()
        {
            var client = Factory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=full");

            var resp = await client.GetAsync("accounts?$select=name");
            resp.EnsureSuccessStatusCode();
        }


        [TestMethod]
        public async Task Should_Return_Full_Metadata_For_Function()
        {
            var client = Factory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=full");

            var resp = await client.GetAsync("accounts/1c82f39e-462e-4e76-ac84-7fb9ca4827b9/GetUsers()?$select=name");
            resp.EnsureSuccessStatusCode();
        }
    }
}
