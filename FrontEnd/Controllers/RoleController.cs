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
    public class RoleController : ControllerBase
    {
        private string apiUrl = "http://localhost:63304/role";

        [HttpGet("get")]
        public dynamic GetAllRoles()
        {
            try
            {
                string urlGetAll = this.apiUrl + "/get";
                var getResponse = JObject.Parse(Http.GetCall(urlGetAll, "GET"));
                
                return JsonConvert.SerializeObject(getResponse, Formatting.Indented);
                
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }

        [HttpDelete("delete/{id}")]
        public dynamic Delete(Int32 id)
        {
            try
            {
                string urlGetAll = this.apiUrl + "/delete/" + id;
                var getResponse = JObject.Parse(Http.GetCall(urlGetAll, "DELETE"));
                return JsonConvert.SerializeObject(getResponse, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }
    }
}
