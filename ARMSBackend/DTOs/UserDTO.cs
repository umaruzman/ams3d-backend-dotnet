using ARMSBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public UserDTO(User user)
        {
            this.Name = user.Name;
            this.Password = user.Password;
        }
    }
}
