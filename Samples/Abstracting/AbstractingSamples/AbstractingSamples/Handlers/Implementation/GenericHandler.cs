using AbstractingSamples.Handlers.Definition;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractingSamples.Handlers.Implementation
{
    public abstract class GenericHandler : IHandler
    {
        public abstract string IntentName { get; }
        public abstract Type RequestType { get; }
        public abstract Task<SkillResponse> HandleAsync(SkillRequest request);
        public virtual bool CanHandle(SkillRequest request)
        {
            if (request.GetRequestType() != RequestType)
                return false;
            if(request.GetRequestType() == typeof(IntentRequest))
            {
                if ((request?.Request as IntentRequest)?.Intent?.Name != IntentName)
                    return false;
            }
            return true;
        }
    }
}
