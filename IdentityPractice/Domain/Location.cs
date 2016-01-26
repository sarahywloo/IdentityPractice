using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Domain {
    public class Location : IDbEntity, IActivatable {

        public int Id { get; set; }
        public IList<Post> Posts { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Active { get; set; } = true;
    }
}