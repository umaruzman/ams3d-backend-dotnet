using ARMSBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public bool UserStatus { get; set; }
        public UserRole UserRole { get; set; }
        public Branch? Branch { get; set; }
        public Organization? Organization { get; set; }
    }
}
