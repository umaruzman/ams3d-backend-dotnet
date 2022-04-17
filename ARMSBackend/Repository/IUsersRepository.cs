using ARMSBackend.Models;
using System.Collections.Generic;

namespace ARMSBackend.Repository
{
    public interface IUsersRepository
    {
        List<User> AllUsers();
        User GetUser(int userid);
        User AddUser(User user);

    }
}
