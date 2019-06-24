using AbstractingSamples.Handlers.Definition;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractingSamples.Handlers.Implementation
{
    public class SimpleLaunchHandler : GenericHandler, IHandler
    {
        public override string IntentName => null;

        public override Type RequestType => typeof(LaunchRequest);

        public override Task<SkillResponse> HandleAsync(SkillRequest request)
        {
            return Task.FromResult(ResponseBuilder.Ask("Welcome to abstracted .NET Alexa Skills. How can I help?", null));
        }
    }
}
