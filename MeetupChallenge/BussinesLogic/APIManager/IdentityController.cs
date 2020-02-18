using BussinesLogic.APIManager;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BussinesLogic.APIManager
{
    public class IdentityController
    {

        private static TokenResponse Token { get; set; }
        public static async Task<TokenResponse> GetToken()
        {
            // discover endpoints from metadata

            if (Token != null && !Token.IsError)

                return Token;

            var client = APIHelper.GetApiClient();

            //cambiar a la dire del servidor entity
            var disco = await client.GetDiscoveryDocumentAsync("https://meetup-identity.azurewebsites.net");

            if (disco.IsError)
            {
                throw new Exception("Error Obteniendo Discovery document");
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "MeetupClient",
                ClientSecret = "secret",

                Scope = "MeetupApi"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                throw new Exception("Error obteniendo token");
            }

            Token = tokenResponse;

            return Token;
       
        }
    }
}
