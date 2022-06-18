using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace ARMSBackend.Models
{
    public class User : BaseEntity
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DefaultValue("user")]
        public string UserType { get; set; }
        [DefaultValue(true)]
        public bool UserStatus { get; set; }
        [DefaultValue(1)]
        public UserRole UserRole { get; set; }
        public Branch? Branch { get; set; }
        public Organization? Organization { get; set; }

    }
}
