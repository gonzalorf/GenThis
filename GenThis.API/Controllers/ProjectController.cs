using GenThis.API.Storage;
using GenThis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenThis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> logger;
        private IStorage storage;

        public ProjectController(ILogger<ProjectController> logger, IStorage storage)
        {
            this.logger = logger;
            this.storage = storage;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Project> GetAll()
        {
            return storage.GetAll(null);
        }

        [HttpGet]
        [Route("Get")]
        public Project Get(Guid projectID)
        {
            return storage.GetProject(projectID);
        }

        [HttpPost]
        [Route("Save")]
        public APIResult<Project> Save(Project project)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(project.Name)) throw new ApplicationException("Project Name is required.");
                storage.Save(project);
                return new APIResult<Project>() { Result = true, ReturnData = project };
            }
            catch (ApplicationException ex)
            {
                logger.LogError(ex, ex.Message);
                return new APIResult<Project>() { Result = false, Message = "Unable to create the new Project. " + ex.Message };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
                return new APIResult<Project>() { Result = false, Message = "Unexpected server side error. Try again." };
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public APIResult<Project> Delete(Project project)
        {
            try
            {
                storage.Delete(project);
                return new APIResult<Project>() { Result = true, ReturnData = project };
            }
            catch (ApplicationException ex)
            {
                logger.LogError(ex, ex.Message);
                return new APIResult<Project>() { Result = false, Message = "Unable to delete the new Project. " + ex.Message };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
                return new APIResult<Project>() { Result = false, Message = "Unexpected server side error. Try again." };
            }
        }
    }
}
