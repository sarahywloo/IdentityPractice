using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Domain {
    public class Post : IDbEntity, IActivatable {

        public int Id { get; set; }
        public string Message { get; set; }
        public IList<Category> Categories { get; set; }
        public Location Location { get; set; }
        public Picture Picture { get; set; }
        public ApplicationUser Owner { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
    }
}