using IdentityPractice.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityPractice.Infrastructure {
    public class PostRepository : GenericRepository<Post> {
        public PostRepository(DbContext db) : base(db) { }

        public IList<Post> GetNewsFeed(ApplicationUser currentUser) {

            //iterate over all followers to find current user
            var followings = from u in _db.Set<ApplicationUser>()
                             from following in u.Following
                             where u.UserName == currentUser.UserName
                             select following.UserName;

            return (from p in Table //in post repository
                        .Include(p => p.Owner)
                        .Include(p => p.Categories)
                        .Include(p => p.Location)
                        .Include(p => p.Picture)
                    where p.Active && (p.Owner.UserName == currentUser.UserName ||
                                       followings.Contains(p.Owner.UserName)) //checks if a 'friend' (a variable) owns the post
                    orderby p.CreatedDate descending
                    select p).ToList();
        }
    }

}