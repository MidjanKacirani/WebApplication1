using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using EntityModel;

namespace WebApplication1.Auth
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IWeatherContext db;
        public AuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, IWeatherContext db) : base(options, logger, encoder, clock)
        {
            this.db = db;
        } 
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authHeader = Context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = usernamePassword.IndexOf(':');

                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);

                if (db.Users.Any(x => x.Username == username && x.Password == password))
                {
                    var claims = new[] { new Claim("name", username), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));

                }
            }
            else
            {
                //Handle what happens if that isn't the case
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            return Task.FromResult(AuthenticateResult.Fail("Failed to authenticate!"));
        }
    }
}
