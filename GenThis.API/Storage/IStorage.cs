using GenThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenThis.API.Storage
{
    public interface IStorage
    {
        Project GetProject(Guid guid);

        void SaveProject(Project project);

        void DeleteProject(Guid projectId);
        
        IList<Project> GetAllProjects(User owner);

        Template GetTemplate(Guid guid);

        void SaveTemplate(Template template);

        void DeleteTemplate(Guid templateId);

        IList<Template> GetAllTemplates(User owner);

    }
}
