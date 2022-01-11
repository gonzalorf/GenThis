using GenThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenThis.API.Storage
{
    public class InMemoryStorage : IStorage
    {
        static IDictionary<Guid, Project> db = new Dictionary<Guid, Project>();

        public void Delete(Guid projectId)
        {
            db.Remove(projectId);
        }

        public IList<Project> GetAll(User owner)
        {
            if (owner == null)
            {
                return db.Values.ToList();
            }
            else
            {
                return db.Where(p => p.Value.Owner.Id == owner.Id).Select(p => p.Value).ToList();
            }
        }

        public Project GetProject(Guid guid)
        {
            return db.First(p => p.Value.Id == guid).Value;
        }

        public void Save(Project project)
        {
            if (db.ContainsKey(project.Id))
            {
                db[project.Id] = project;
            }
            else
            {
                db.Add(project.Id, project);
            }    
        }
    }
}
