using ARMSBackend.Models;

namespace ARMSBackend.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
