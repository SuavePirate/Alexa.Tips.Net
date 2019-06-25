using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractingSamples.Handlers.Definition;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;

namespace AbstractingSamples.Handlers.Implementation
{
    public class DogFactHandler : GenericHandler, IHandler
    {
        public override string IntentName => "DogFactIntent";

        public override Type RequestType => typeof(IntentRequest);

        public override Task<SkillResponse> HandleAsync(SkillRequest request)
        {
            return Task.FromResult(ResponseBuilder.Tell("Dogs do in fact have a sense of time, and even miss you when you're gone."));
        }
    }
}
