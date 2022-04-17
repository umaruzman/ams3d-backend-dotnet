using Swashbuckle.AspNetCore.Annotations;

namespace ARMSBackend.Models
{
    public class User
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
