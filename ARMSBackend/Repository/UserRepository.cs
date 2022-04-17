using ARMSBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend.Repository
{
    public class UserRepository : IUsersRepository
    {

        private AppContext _context;

        public UserRepository(AppContext context)
        {
            this._context = context;
        }

        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> AllUsers()
        {
            List<User> users = _context.Users.ToList();

            return users;
        }

        public User GetUser(int userid)
        {
            User user = _context.Users.Find(userid);
            return user;
        }
    }
}
