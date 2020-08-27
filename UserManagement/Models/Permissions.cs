using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class Permissions
    {
        public Permissions()
        {
            PermissionsRoles = new HashSet<PermissionsRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PublicName { get; set; }
        public string Routes { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PermissionsRoles> PermissionsRoles { get; set; }
    }
}
