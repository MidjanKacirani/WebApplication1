using Castle.Core.Logging;
using EntityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Moq;
using WebApplication1.Auth;
using Extension = Microsoft.Extensions.Logging;

namespace TestProject1
{
    public class AuthTest
    {

        private readonly Mock<IWeatherContext> dbMock;
        private readonly Mock<Extension.ILoggerFactory> loggerMock;
        private readonly Mock<IOptionsMonitor<AuthenticationSchemeOptions>> optionsMock;
        private readonly AuthenticationHandler sut;
        private readonly Mock<System.Text.Encodings.Web.UrlEncoder> urlMock;
        private readonly Mock<Microsoft.AspNetCore.Authentication.ISystemClock> clockMock;
        public AuthTest()
        {
            dbMock = new Mock<IWeatherContext>();
            loggerMock = new Mock<Extension.ILoggerFactory>();
            optionsMock = new Mock<IOptionsMonitor<AuthenticationSchemeOptions>>();
            urlMock = new Mock<System.Text.Encodings.Web.UrlEncoder>();
            clockMock = new Mock<Microsoft.AspNetCore.Authentication.ISystemClock>();
            sut = new AuthenticationHandler(optionsMock.Object, loggerMock.Object, urlMock.Object, clockMock.Object, dbMock.Object);
        }

        [Fact]
        public async Task AuthorizationHandler_Test_DoesNotStartWithBasic()
        {
            var result =  await sut.HandleAuthentication("invalid header here");

            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task AuthorizationHandler_Test_UnauthorizedAsync()
        {
            var result = await sut.HandleAuthentication("Basic invalid header here");

            Assert.False(result.Succeeded);
        }
    }
}