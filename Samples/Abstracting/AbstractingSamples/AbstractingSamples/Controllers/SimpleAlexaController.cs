using Alexa.NET.Request;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractingSamples.Controllers
{
    [Route("[controller]")]
    public class SimpleAlexaController : Controller
    {
        [HttpPost]
        public async Task<SkillResponse> HandleRequest([FromBody]SkillRequest request)
        {
            return null;
        }
    }
}
