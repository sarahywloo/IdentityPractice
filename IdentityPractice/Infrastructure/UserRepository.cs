using IdentityPractice.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityPractice.Infrastructure {
    public class UserRepository {

        private ApplicationDbContext _db;

        //Injecting a DbContext and typecast it, Ninject will look at it as building a DbContext
        //Binds ApplicationDbContext in request scope
        public UserRepository(DbContext db) {
            _db = (ApplicationDbContext)db;
        }

        //gets followings
        public IQueryable<ApplicationUser> GetFollowings(string username) {
            //selects current username and all followings associated with it
            return  from u in _db.Users
                    from following in u.Following
                    where u.UserName == username
                    //joins the result into a single list of friends
                    select following;
        }

        public bool DoesUserExist(string userName) {
            return _db.Users.Any(u => u.UserName == userName);
        }
    }
}