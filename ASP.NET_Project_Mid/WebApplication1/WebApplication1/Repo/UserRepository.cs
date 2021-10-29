using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public class UserRepository
    {
        static HomeRentEntities db;
        static UserRepository()
        {
            db = new HomeRentEntities();
        }

        public static User Get(string email)
        {
            var u = (from us in db.Users
                     where us.Email == email
                     select us).FirstOrDefault();
            return u;
        }

        public static User Authenticate(string email, string password)
        {
            var u = (from us in db.Users
                     where us.Email == email &&
                     us.Password == password
                     select us).FirstOrDefault();
            var user = db.Users.FirstOrDefault(e => u.Email == email && u.Password == password);
            return u;
        }
    }
}