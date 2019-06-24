using Alexa.NET.Request;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractingSamples.Handlers.Definition
{
    public interface IHandler
    {
        string IntentName { get; }
        Type RequestType { get; }
        Task<SkillResponse> HandleAsync(SkillRequest request);
        bool CanHandle(SkillRequest request);
    }
}
