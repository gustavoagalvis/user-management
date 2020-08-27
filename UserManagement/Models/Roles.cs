using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class Roles
    {
        public Roles()
        {
            PermissionsRoles = new HashSet<PermissionsRoles>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PermissionsRoles> PermissionsRoles { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
