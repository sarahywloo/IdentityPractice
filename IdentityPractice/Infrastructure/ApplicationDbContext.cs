using IdentityPractice.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityPractice.Infrastructure {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Location> Location { get; set; }
        public IDbSet<Picture> Pictures { get; set; }
    }
}