using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int RolesId { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
