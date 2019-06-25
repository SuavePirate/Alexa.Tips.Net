using AbstractingSamples.Handlers.Definition;
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
        private readonly ICollection<IHandler> _handlers;
        public SimpleAlexaController(ICollection<IHandler> handlers)
        {
            _handlers = handlers;
        }
        [HttpPost]
        public async Task<SkillResponse> HandleRequest([FromBody]SkillRequest request)
        {
            var viableHandler = _handlers.FirstOrDefault(h => h.CanHandle(request));
            return await viableHandler.HandleAsync(request);
        }
    }
}
