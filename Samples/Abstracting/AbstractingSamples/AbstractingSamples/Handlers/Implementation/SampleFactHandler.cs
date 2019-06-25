using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractingSamples.Contexts;
using AbstractingSamples.Handlers.Definition;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.EntityFrameworkCore;

namespace AbstractingSamples.Handlers.Implementation
{
    public class SampleFactHandler : GenericHandler, IHandler
    {
        private readonly SampleMessageDbContext _context;
        public SampleFactHandler(SampleMessageDbContext context)
        {
            _context = context;
        }
        public override string IntentName => "SampleMessageIntent";

        public override Type RequestType => typeof(IntentRequest);

        public override async Task<SkillResponse> HandleAsync(SkillRequest request)
        {
            // just grab one as an example
            var message = await _context.SampleMessages.FirstOrDefaultAsync();
            return ResponseBuilder.Tell(message?.Content ?? "I don't have any messages for you.");
        }
    }
}
