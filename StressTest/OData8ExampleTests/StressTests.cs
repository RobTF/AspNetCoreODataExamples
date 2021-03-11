using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ODataExample;

namespace OData8ExampleTests
{
    [TestClass]
    public class StressTests
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
        public async Task Should_Deal_With_High_Volume_Of_Calls()
        {
            var client = Factory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=minimal");

            var tasks = new List<Task>();
            for (var i = 0; i < 50; i++)
            {
                tasks.Add(GetData());
            }

            await Task.WhenAll(tasks);
        }

        private async Task GetData()
        {
            var client = Factory.CreateClient();
            var resp = await client.GetAsync("accounts/1c82f39e-462e-4e76-ac84-7fb9ca4827b9/GetUsers()?$select=name");
            resp.EnsureSuccessStatusCode();
            var str = await resp.Content.ReadAsStringAsync();
            Assert.AreEqual(@"{""@odata.context"":""http://localhost/$metadata#Users(name)"",""value"":[{""name"":""User 4""},{""name"":""User 7""},{""name"":""User 8""}]}", str);
        }
    }
}
