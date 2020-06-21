using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Security
{
    public class SigningConfiguration
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials Credentials { get; set; }

        public SigningConfiguration() {
            using (var provider = new RSACryptoServiceProvider(2048))
                Key = new RsaSecurityKey(provider.ExportParameters(true));
                
            Credentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
