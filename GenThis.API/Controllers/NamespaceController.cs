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
    public class NamespaceController : ControllerBase
    {
        private readonly ILogger<ProjectController> logger;

        public NamespaceController(ILogger<ProjectController> logger)
        {
            this.logger = logger;
        }
    }
}
