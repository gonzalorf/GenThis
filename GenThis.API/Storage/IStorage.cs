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

        void Save(Project project);

        void Delete(Project project);
        
        IList<Project> GetAll(User owner);

    }
}
