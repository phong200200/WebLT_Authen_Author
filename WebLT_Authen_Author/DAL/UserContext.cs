using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebLT_Authen_Author.Models;

namespace WebLT_Authen_Author.DAL
{
    public class UserContext:DbContext
    {

        

        public UserContext() : base("UserContext")
        {

        }
        public DbSet<User> users { get; set; }
    }
}