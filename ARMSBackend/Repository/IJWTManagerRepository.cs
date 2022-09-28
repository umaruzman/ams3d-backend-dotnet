using ARMSBackend.DTOs;
using ARMSBackend.Models;

namespace ARMSBackend.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(AuthRequestDTO users);
    }
}
