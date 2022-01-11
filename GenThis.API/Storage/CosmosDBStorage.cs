using GenThis.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// https://docs.microsoft.com/en-us/azure/cosmos-db/sql/sql-api-dotnet-application
/// </summary>
namespace GenThis.API.Storage
{
    public class CosmosDBStorage : IStorage
    {
        private Container container;

        public CosmosDBStorage(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this.container = dbClient.GetContainer(databaseName, containerName);
        }

        public async void Delete(Guid projectId)
        {
            await this.container.DeleteItemAsync<Project>(projectId.ToString(), new PartitionKey(projectId.ToString()));
        }

        public IList<Project> GetAll(Models.User owner)
        {
            var query = this.container.GetItemQueryIterator<Project>(new QueryDefinition("SELECT c.id, c.Name FROM c"));
            List<Project> results = new List<Project>();
            while (query.HasMoreResults)
            {
                var response = query.ReadNextAsync().Result;

                results.AddRange(response.ToList());
            }

            return results;
        }

        public Project GetProject(Guid guid)
        {
            var query = this.container.GetItemQueryIterator<Project>(new QueryDefinition("SELECT * FROM c WHERE c.id = '" + guid.ToString() + "'"));
            List<Project> results = new List<Project>();
            return query.ReadNextAsync().Result.First();
        }

        public async void Save(Project project)
        {
            await this.container.UpsertItemAsync<Project>(project, new PartitionKey(project.Name.ToString()));
        }
    }
}
