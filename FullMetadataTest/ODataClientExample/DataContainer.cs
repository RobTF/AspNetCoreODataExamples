namespace ODataClientExample
{
    using System;
    using Microsoft.OData.Client;
    using ODataExampleCommon;

    /// <summary>
    /// OData client.
    /// </summary>
    internal class DataContainer : DataServiceContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContainer"/> class.
        /// </summary>
        /// <param name="serviceRoot">The service root.</param>
        public DataContainer(Uri? serviceRoot)
            : base(serviceRoot)
        {
            Users = CreateQuery<User>("Users");
            Accounts = CreateQuery<Account>("Accounts");
        }

        /// <summary>
        /// Gets a query of resource warning thresholds.
        /// </summary>
        public DataServiceQuery<User> Users { get; }

        /// <summary>
        /// Gets a query of resource batches.
        /// </summary>
        public DataServiceQuery<Account> Accounts { get; }
    }
}
