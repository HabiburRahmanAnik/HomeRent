using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class UserRepository
    {
        static HomeRentEntities db;

        static UserRepository()
        {
            db = new HomeRentEntities();
        }

        public static void Registration(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public static User Authenction(string email, string password)
        {
            var u = (from us in db.Users
                     where us.Email == email &&
                     us.Password == password
                     select us).FirstOrDefault();
            return u;
        }

        public static User GetUserType(int id)
        {
            var u = (from us in db.Users
                     where us.UserId == id
                     select us).FirstOrDefault();
            return u;
        }
    }
}