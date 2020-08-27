using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class PermissionsRoles
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public virtual Permissions Permission { get; set; }
        public virtual Roles Role { get; set; }
    }
}
