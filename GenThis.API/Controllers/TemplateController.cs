using GenThis.API.Storage;
using GenThis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GenThis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly ILogger<TemplateController> logger;
        private IStorage storage;

        public TemplateController(ILogger<TemplateController> logger, IStorage storage)
        {
            this.logger = logger;
            this.storage = storage;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Template> GetAll()
        {
            return storage.GetAllTemplates(null);
        }

        [HttpGet]
        [Route("Get")]
        public Template Get(Guid templateID)
        {
            return storage.GetTemplate(templateID);
        }

        [HttpPost]
        [Route("Save")]
        public APIResult<Template> Save(Template template)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(template.Name)) throw new ApplicationException("Template Name is required.");
                storage.SaveTemplate(template);
                return new APIResult<Template>() { Result = true, ReturnData = template };
            }
            catch (ApplicationException ex)
            {
                logger.LogError(ex, ex.Message);
                return new APIResult<Template>() { Result = false, Message = "Unable to create the new Template. " + ex.Message };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
                return new APIResult<Template>() { Result = false, Message = "Unexpected server side error. Try again." };
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public APIResult<Guid> Delete(Guid id)
        {
            try
            {
                storage.DeleteTemplate(id);
                return new APIResult<Guid>() { Result = true, ReturnData = id };
            }
            catch (ApplicationException ex)
            {
                logger.LogError(ex, ex.Message);
                return new APIResult<Guid>() { Result = false, Message = "Unable to delete the new Template. " + ex.Message };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
                return new APIResult<Guid>() { Result = false, Message = "Unexpected server side error. Try again." };
            }
        }
    }
}
