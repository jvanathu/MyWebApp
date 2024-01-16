using Microsoft.AspNetCore.Authorization;

namespace MyWebApp.Config.Security
{
    public class ScopeRequirement: IAuthorizationRequirement
    {
        public string Issuer { get; set; }
        public string Scope { get; set; }

        public ScopeRequirement(string scope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}
