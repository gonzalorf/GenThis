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
        static IDictionary<Guid, Template> dbTemplates = new Dictionary<Guid, Template>();

        public void DeleteProject(Guid projectId)
        {
            db.Remove(projectId);
        }

        public void DeleteTemplate(Guid templateId)
        {
            dbTemplates.Remove(templateId);
        }

        public IList<Project> GetAllProjects(User owner)
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

        public IList<Template> GetAllTemplates(User creator)
        {
            if (creator == null)
            {
                return dbTemplates.Values.ToList();
            }
            else
            {
                return dbTemplates.Where(p => p.Value.Creator.Id == creator.Id).Select(p => p.Value).ToList();
            }
        }

        public Project GetProject(Guid guid)
        {
            return db.First(p => p.Value.Id == guid).Value;
        }

        public Template GetTemplate(Guid guid)
        {
            return dbTemplates.First(p => p.Value.Id == guid).Value;
        }

        public void SaveProject(Project project)
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

        public void SaveTemplate(Template template)
        {
            if (dbTemplates.ContainsKey(template.Id))
            {
                dbTemplates[template.Id] = template;
            }
            else
            {
                dbTemplates.Add(template.Id, template);
            }
        }
    }
}
