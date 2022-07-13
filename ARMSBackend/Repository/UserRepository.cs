using ARMSBackend.DTOs;
using ARMSBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            User newUser = user;
            this._context.Users.Add(newUser);
            this._context.SaveChanges();

            return newUser;
        }

        public List<User> AllUsers()
        {
            List<User> users = _context.Users
                .Include(u => u.Branch)
                .Include(u => u.UserRole)
                .Include(u => u.Organization)
                .ToList();

            return users;
        }

        public User GetUser(int userid)
        {
            var user = _context.Users
                .Include(u => u.Branch)
                .Include(u => u.UserRole)
                .Include(u => u.Organization)
                .FirstOrDefault(u => u.Id == userid);

            return user;
        }

        public User UpdateUser(int userid, UserEditDto user)
        {
            try
            {
                var currUser = _context.Users.Find(userid);
                currUser.Username = user.Username;
                currUser.Email = user.Email;
                _context.SaveChanges();
                return currUser;
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public bool DeleteUser(int userid)
        {
            try
            {
                var user = _context.Users.Find(userid);
                _context.Users.Remove(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}
