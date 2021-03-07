using System;
using Microsoft.OData.Client;

namespace ODataExampleCommon
{
    [Key("id")]
    public class Account
    {
        [OriginalName("id")]
        public Guid Id { get; set; }

        [OriginalName("name")]
        public string Name { get; set; }
    }
}
