using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;
using UserManagement.Dto;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Net.Mime;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IDbContextTransaction transaction = null;

        [HttpGet("get")]
        public CustomResponse GetAllRoles()
        {
            try
            {
                UserManagementContext context = new UserManagementContext();

                var objectList = context.Roles.Select(role => new RolesDto
                {
                     Id = role.Id, 
                    Role = role.Role 
                }).ToList();
                return new CustomResponse { State = 200, Message = "Listado exitoso", Custom = objectList };
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }
    }
}
