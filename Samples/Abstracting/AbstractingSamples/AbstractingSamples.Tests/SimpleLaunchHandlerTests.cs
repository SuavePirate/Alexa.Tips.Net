using AbstractingSamples.Handlers.Implementation;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AbstractingSamples.Tests
{
    public class SimpleLaunchHandlerTests : IClassFixture<SimpleLaunchHandler>
    {
        private readonly SimpleLaunchHandler _subject;
        public SimpleLaunchHandlerTests()
        {
            _subject = new SimpleLaunchHandler();
        }

        [Fact]
        public async Task SimpleHandler_ReturnsResponse()
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
            var response = await _subject.HandleAsync(request);

            // assert
            Assert.NotNull((response.Response.OutputSpeech as PlainTextOutputSpeech)?.Text);
        }

        [Fact]
        public void SimpleHandler_CanHandleLaunchRequest()
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
            Assert.True(canHandle);
        }
        [Fact]
        public void SimpleHandler_CanNotHandleIntentRequest()
        {
            // arrange
            var request = new SkillRequest()
            {
                Version = "1.0",
                Request = new IntentRequest
                {
                    Type = "IntentRequest"
                }
            };

            // act
            var canHandle = _subject.CanHandle(request);

            // assert
            Assert.False(canHandle);
        }
    }
}
