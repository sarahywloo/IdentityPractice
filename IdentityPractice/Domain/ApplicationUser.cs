using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace IdentityPractice.Domain {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationUser : IdentityUser {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public IList<Post> Posts { get; set; }
        public IList<ApplicationUser> Followers { get; set; }

        [InverseProperty("Followers")]
        public IList<ApplicationUser> Following { get; set; }

        public Picture ProfilePicture { get; set; }
        public IList<Picture> Pictures { get; set; }
    }

}