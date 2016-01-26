using IdentityPractice.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityPractice.Infrastructure {
    public class PostRepository : GenericRepository<Post> {
        public PostRepository(DbContext db) : base(db) { }

        //an array of usernames is passed in as a parameter
        public IQueryable<Post> GetPostsForUsers(params string[] usernames) {

            return from p in Table //in post repository
                   where p.Active && (usernames.Contains(p.Owner.UserName)) //checks if a 'friend' (a variable) owns the post
                   orderby p.CreatedDate descending
                   select p;
        }
    }

}