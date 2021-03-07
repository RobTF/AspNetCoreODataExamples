using System;
using Microsoft.OData.Client;

namespace ODataExampleCommon
{
    [Key("id")]
    public class User
    {
        [OriginalName("id")]
        public Guid Id { get; set; }

        [OriginalName("name")]
        public string Name { get; set; }

        [OriginalName("groupName")]
        public string GroupName { get; set; }
    }
}
