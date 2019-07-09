using AbstractingSamples.Contexts;
using AbstractingSamples.Handlers.Implementation;
using AbstractingSamples.Models;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AbstractingSamples.Tests.UnitTests
{
    public class SampleFactHandlerTests
    {
        [Fact]
        public async Task SampleFactHandler_ReturnResponseWithData()
        {
            // arrange
            var context = new Mock<SampleMessageDbContext>();
            context.Setup(d => d.SampleMessages.FirstOrDefaultAsync(CancellationToken.None)).Returns(Task.FromResult(new SampleMessage
            {
                Id = Guid.NewGuid().ToString(),
                Content = "This is a mocked response message"
            }));
            var subject = new SampleFactHandler(context.Object);

            // arrange
            var request = new SkillRequest()
            {
                Version = "1.0",
                Request = new IntentRequest
                {
                    Type = "IntentRequest",
                    Intent = new Intent
                    {
                        Name = "SampleMessageIntent"
                    }
                }
            };

            // act
            var response = await subject.HandleAsync(request);

            // assert
            Assert.NotNull((response.Response.OutputSpeech as PlainTextOutputSpeech)?.Text);
        }
        [Fact]
        public async Task SampleFactHandler_ReturnFallbackResponseWithNoData()
        {
            // arrange
            var context = new Mock<SampleMessageDbContext>();
            context.Setup(d => d.SampleMessages.FirstOrDefaultAsync(CancellationToken.None)).Returns(Task.FromResult<SampleMessage>(null));
            var subject = new SampleFactHandler(context.Object);

            // arrange
            var request = new SkillRequest()
            {
                Version = "1.0",
                Request = new IntentRequest
                {
                    Type = "IntentRequest",
                    Intent = new Intent
                    {
                        Name = "SampleMessageIntent"
                    }
                }
            };

            // act
            var response = await subject.HandleAsync(request);

            // assert
            Assert.True((response.Response.OutputSpeech as PlainTextOutputSpeech)?.Text == "I don't have any messages for you.");
        }
    }
}
