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

        public void Delete(Project project)
        {
            db.Remove(project.ID);
        }

        public IList<Project> GetAll(User owner)
        {
            if (owner == null)
            {
                return db.Values.ToList();
            }
            else
            {
                return db.Where(p => p.Value.Owner.ID == owner.ID).Select(p => p.Value).ToList();
            }
        }

        public Project GetProject(Guid guid)
        {
            return db.First(p => p.Value.ID == guid).Value;
        }

        public void Save(Project project)
        {
            if (db.ContainsKey(project.ID))
            {
                db[project.ID] = project;
            }
            else
            {
                db.Add(project.ID, project);
            }    
        }
    }
}
