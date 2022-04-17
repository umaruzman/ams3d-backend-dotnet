using ARMSBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend.Repository
{
    public interface IUsersRepository
    {
        List<User> AllUsers();
        User GetUser(int userid);

        User AddUser(User user);

    }
}
