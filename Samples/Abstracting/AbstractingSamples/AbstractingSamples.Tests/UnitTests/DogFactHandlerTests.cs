using AbstractingSamples.Handlers.Implementation;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AbstractingSamples.Tests.UnitTests
{
    public class DogFactHandlerTests : IClassFixture<DogFactHandler>
    {
        private readonly DogFactHandler _subject = new DogFactHandler();


        [Fact]
        public async Task DogFactHandler_ReturnsResponse()
        {
            // arrange
            var request = new SkillRequest()
            {
                Version = "1.0",
                Request = new IntentRequest
                {
                    Type = "IntentRequest",
                    Intent = new Intent
                    {
                        Name = "DogFactIntent"
                    }
                }
            };

            // act
            var response = await _subject.HandleAsync(request);

            // assert
            Assert.NotNull((response.Response.OutputSpeech as PlainTextOutputSpeech)?.Text);
        }

        [Fact]
        public void DogFactHandler_CanHandleIntentRequest()
        {
            // arrange
            var request = new SkillRequest()
            {
                Version = "1.0",
                Request = new IntentRequest
                {
                    Type = "IntentRequest",
                    Intent = new Intent
                    {
                        Name = "DogFactIntent"
                    }
                }
            };
            // act
            var canHandle = _subject.CanHandle(request);

            // assert
            Assert.True(canHandle);
        }
        [Fact]
        public void DogFactHandler_CanNotHandleLaunchRequest()
        {
            // arrange
            var request = new SkillRequest()
            {
                Version = "1.0",
                Request = new LaunchRequest
                {
                    Type = "LaunchRequest"
                }
            };
          

            // act
            var canHandle = _subject.CanHandle(request);

            // assert
            Assert.False(canHandle);
        }
        [Fact]
        public void DogFactHandler_CanNotHandleOtherIntents()
        {
            // arrange
            var request = new SkillRequest()
            {
                Version = "1.0",
                Request = new IntentRequest
                {
                    Type = "IntentRequest",
                    Intent = new Intent
                    {
                        Name = "AMAZON.HelpIntent"
                    }
                }
            };


            // act
            var canHandle = _subject.CanHandle(request);

            // assert
            Assert.False(canHandle);
        }
    }
}
