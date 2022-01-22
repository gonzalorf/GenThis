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

        public async void DeleteProject(Guid projectId)
        {
            await this.container.DeleteItemAsync<Project>(projectId.ToString(), new PartitionKey(projectId.ToString()));
        }

        public void DeleteTemplate(Guid templateId)
        {
            throw new NotImplementedException();
        }

        public IList<Project> GetAllProjects(Models.User owner)
        {
            var query = this.container.GetItemQueryIterator<Project>(new QueryDefinition("SELECT c.id, c.Name, c.Description FROM c"));
            List<Project> results = new List<Project>();
            while (query.HasMoreResults)
            {
                var response = query.ReadNextAsync().Result;

                results.AddRange(response.ToList());
            }

            return results;
        }

        public IList<Template> GetAllTemplates(Models.User owner)
        {
            throw new NotImplementedException();
        }

        public Project GetProject(Guid guid)
        {
            var query = this.container.GetItemQueryIterator<Project>(new QueryDefinition("SELECT * FROM c WHERE c.id = '" + guid.ToString() + "'"));
            List<Project> results = new List<Project>();
            return query.ReadNextAsync().Result.First();
        }

        public Template GetTemplate(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async void SaveProject(Project project)
        {
            await this.container.UpsertItemAsync<Project>(project, new PartitionKey(project.Name.ToString()));
        }

        public void SaveTemplate(Template template)
        {
            throw new NotImplementedException();
        }
    }
}
