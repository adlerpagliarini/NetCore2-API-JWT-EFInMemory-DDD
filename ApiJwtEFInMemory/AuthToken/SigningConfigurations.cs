using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ApiJwtEFInMemory.AuthToken
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; } // encrypted key generated on token creation;
        public SigningCredentials SigningCredentials { get; } // algorithm used on token creation and encrypted key

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
