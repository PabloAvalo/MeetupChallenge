using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Controllers
{
    [Route("Identity")]
    
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
        /// <summary>
        /// Solo con motivo de prueba para pasar el token a swagger
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]


        public async Task<IActionResult> GetTokenAsync()
        {

            var client = new System.Net.Http.HttpClient();

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
                //bad request?
                return BadRequest();
            }

            return Ok(new { token = tokenResponse.AccessToken });

        }


    }
}
