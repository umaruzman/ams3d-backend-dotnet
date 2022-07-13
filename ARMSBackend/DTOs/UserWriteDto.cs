using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend.DTOs
{
    public class UserWriteDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DefaultValue("user")]
        public string UserType { get; set; }
        [DefaultValue(true)]
        public bool UserStatus { get; set; }
        [DefaultValue(1)]
        public int UserRoleId { get; set; }
        public int? BranchId { get; set; }
        public int? OrganizationId { get; set; }
    }
}
