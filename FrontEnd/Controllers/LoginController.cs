using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FrontEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private string apiUrl = "http://localhost:63304/user";
        [HttpPost("newlogin")]
        public dynamic Login([FromBody] LoginDto loginUser)
        {
            try
            {
                string urlNewLogin = this.apiUrl + "/newlogin";
                string parsedContent = "{" +
                    "\"Username\":\"" + loginUser.Username + "\"," +
                    "\"Password\":\"" + loginUser.Password + "\"" +
                "}";

                var getResponse = JObject.Parse(Http.PostCall(urlNewLogin, parsedContent, "POST"));
                return JsonConvert.SerializeObject(getResponse, Formatting.Indented);
                
                //return  getResponse);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
