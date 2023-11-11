using CustomerApp.Core.Interfaces;
using CustomerApp.Core.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;

namespace CustomerApp.Infrastructure.CosmosData
{
    public class CustomerCosmosRepository : ICustomerRepository
    {
    

        private CosmosClient _cosmosClient;
        private Database _database;
        private Container _container;
        public async Task<int> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetCustomerDetails( IEnumerable<ConfigDetails> configDetails)
        {
            string query = "SELECT * FROM c";

            string cosmosEndpoint = "https://cosmosdbsharan.documents.azure.com:443/"; 
            string cosmosKey = null;
            string databaseName = null;
            string containerName = null;

            foreach (ConfigDetails config in configDetails)
            {
                if (configDetails.Any())
                {
                    if (config.Type == "Azure")
                    {
                        cosmosKey = config.DatabaseConn;
                        databaseName = config.DatabaseName;
                        containerName = config.ContainerName;
                    }
                }
            }


            var results = new List<Customer>();
            _cosmosClient = new CosmosClient(cosmosEndpoint, cosmosKey);
            _database = _cosmosClient.GetDatabase(databaseName);
            _container = _database.GetContainer(containerName);

            var queryDefinition = new QueryDefinition(query);
            FeedIterator<Customer> resultSet = _container.GetItemQueryIterator<Customer>(queryDefinition);

            while (resultSet.HasMoreResults)
            {
              
                    var response = await resultSet.ReadNextAsync();

                    FeedResponse<Customer> currentResultSet = response;
                    results.AddRange(currentResultSet);
               
            }

            return results;
        }
    }
}