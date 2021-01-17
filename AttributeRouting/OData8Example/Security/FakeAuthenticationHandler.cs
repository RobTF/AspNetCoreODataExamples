using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ODataExample.Security
{
    public class FakeAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public FakeAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, loggerFactory, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var retval = AuthenticateResult.NoResult();

            if (Request.Headers.ContainsKey("Authorization"))
            {
                var rawToken = Request.Headers["Authorization"].First();
                if (rawToken.StartsWith("Bearer"))
                {
                    var split = rawToken.Split(' ');

                    var token = split[1];
                    var claims = new List<Claim>();
                    if (token == "abc")
                    {
                        claims.Add(new Claim("api.group", "Retail"));
                    }
                    else
                    {
                        claims.Add(new Claim("api.group", "CustomerSupport"));
                    }

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    retval = AuthenticateResult.Success(ticket);
                }
            }

            return Task.FromResult(retval);
        }
    }
}
