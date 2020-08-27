using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FrontEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private string apiUrl = "http://localhost:63304/user";

        [HttpGet("get/{id}")]
        public dynamic GetUser(Int32 id)
        {
            try
            {
                string urlGet = this.apiUrl + "/get/" + id;
                var getResponse = JObject.Parse(Http.GetCall(urlGet, "GET"));
                return JsonConvert.SerializeObject(getResponse, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }


        [HttpGet("get")]
        public dynamic GetAllUsers()
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

        [HttpPut("put/{id}")]
        public dynamic Put(int id, [FromBody] UsersDto user)
        {
            try
            {
                string urlUserPut = this.apiUrl + "/put/" + id;;
                string parsedContent = "{" +
                    "\"Id\":" + user.Id + "," +
                    "\"Username\":\"" + user.Username + "\"," +
                    "\"Fullname\":\"" + user.Fullname + "\"," +
                    "\"Address\":\"" + user.Address + "\"," +
                    "\"Phone\":\"" + user.Phone + "\"," +
                    "\"Email\":\"" + user.Email + "\"," +
                    "\"Age\":" + user.Age + "," +
                    "\"RolesId\":" + user.RolesId  +
                "}";

                var getResponse = JObject.Parse(Http.PostCall(urlUserPut, parsedContent, "PUT"));

                return JsonConvert.SerializeObject(getResponse, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }

        [HttpPost("post")]
        public dynamic Post([FromBody] UsersDto user)
        {
            try
            {
                string urlUserPut = this.apiUrl + "/post";
                string parsedContent = "{" +
                    "\"Username\":\"" + user.Username + "\"," +
                    "\"Password\":\"" + user.Password + "\"," +
                    "\"Fullname\":\"" + user.Fullname + "\"," +
                    "\"Address\":\"" + user.Address + "\"," +
                    "\"Phone\":\"" + user.Phone + "\"," +
                    "\"Email\":\"" + user.Email + "\"," +
                    "\"Age\":" + user.Age + "," +
                    "\"RolesId\":" + user.RolesId +
                "}";

                var getResponse = JObject.Parse(Http.PostCall(urlUserPut, parsedContent, "POST"));

                return JsonConvert.SerializeObject(getResponse, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }

        [HttpDelete("delete/{id}")]
        public dynamic Delete(int id)
        {
            try
            {
                string urlDelete = this.apiUrl + "/delete/" + id;
                var getResponse = JObject.Parse(Http.GetCall(urlDelete, "DELETE"));
                return JsonConvert.SerializeObject(getResponse, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }
    }
}
