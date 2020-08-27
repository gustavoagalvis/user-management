using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;
using UserManagement.Dto;
using Microsoft.EntityFrameworkCore.Storage;
using System.Net.Mime;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IDbContextTransaction transaction = null;

        [HttpGet("get/{id}")]
        public CustomResponse Get(int id)
        {
            try
            {
                var context = new UserManagementContext();


                var objectUser = context.Users.Where(u => u.Id == id).Select(user => new UsersDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Fullname = user.Fullname,
                    Address = user.Address,
                    Phone = user.Phone,
                    Email = user.Email,
                    Age = user.Age,
                    RolesId = user.RolesId,
                    Roles = new RolesDto { Id = user.Roles.Id, Role = user.Roles.Role },
                    Permissions = user.Roles.PermissionsRoles.Select(permissions => permissions.Permission).ToList()

                }).FirstOrDefault();
                if (objectUser is null)
                    return new CustomResponse { State = 405, Message = "Usuario no encontrado" };
                else
                    return new CustomResponse { State = 200, Message = "Usuario encontrado", Custom = objectUser };

            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }

        [HttpGet("get")]
        public CustomResponse GetAllUsers()
        {
            try
            {
                UserManagementContext context = new UserManagementContext();

                var objectList = context.Users.Select(user => new UsersDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Fullname = user.Fullname,
                    Address = user.Address,
                    Phone = user.Phone,
                    Email = user.Email,
                    Age = user.Age,
                    RolesId = user.RolesId,
                    Roles = new RolesDto { Id = user.Roles.Id, Role = user.Roles.Role },
                    Permissions = user.Roles.PermissionsRoles.Select(permissions => permissions.Permission).ToList()

                }).ToList();
                return new CustomResponse { State = 200, Message = "Listado exitoso", Custom = objectList };
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }


        [HttpPost("newlogin")]
        public CustomResponse NewLogin([FromBody] LoginDto login)
        {
            try
            {
                var context = new UserManagementContext();

                var objectUser = context.Users.Where(u => (u.Username == login.Username && u.Password == login.Password)).Select(user => new UsersDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Fullname = user.Fullname,
                    Address = user.Address,
                    Phone = user.Phone,
                    Email = user.Email,
                    Age = user.Age,
                    RolesId = user.RolesId,
                    Roles = new RolesDto { Id = user.Roles.Id, Role = user.Roles.Role },
                    Permissions = user.Roles.PermissionsRoles.Select(permissions => permissions.Permission).ToList()

                }).FirstOrDefault();
                if (objectUser is null)
                    return new CustomResponse { State = 405, Message = "Usuario no encontrado"};
                else
                    return new CustomResponse { State = 200, Message = "Ingreso exitoso", Custom = objectUser };
                
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }

        [HttpPost("post")]
        public CustomResponse  Post([FromBody] Users user)
        {
            try
            {
                using (var context = new UserManagementContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }

                return new CustomResponse { State = 200, Message = "Creación exitosa" };
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }

        [HttpPut("put/{id}")]
        public CustomResponse Put(int id, [FromBody] Users user)
        {
            try
            {
                if (id != user.Id)
                {
                    return new CustomResponse { State = 400, Message = "Error en la solicitud, deben coincidir los ids" };
                }

                using (var context = new UserManagementContext())
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.Entry(user).Property(x => x.Password).IsModified = false;
                    context.SaveChanges();
                }

                return new CustomResponse { State = 200, Message = "Modificación exitosa" };
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }

        [HttpDelete("delete/{id}")]
        public CustomResponse Delete(int id)
        {
            try
            {
                using (var context = new UserManagementContext())
                {
                    Users user = context.Users.Where(x => x.Id == id).FirstOrDefault();
                    if (user != null)
                    { 
                        context.Users.Remove(user);
                        context.SaveChanges();
                        return new CustomResponse { State = 200, Message = "Eliminación exitoso" };
                    } else
                    {
                        return new CustomResponse { State = 405, Message = "Usuario no encontrado" };
                    } 
                }
            }
            catch (Exception ex)
            {
                return new CustomResponse { State = 500, Message = ex.Message.ToString() };
            }
        }
    }
}
