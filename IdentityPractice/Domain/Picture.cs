using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityPractice.Domain {
    public class Picture : IDbEntity, IActivatable {

        public int Id { get; set; }

        //To specify the inverse property
        [InverseProperty("Pictures")]
        public ApplicationUser Owner { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; } = true;
    }
}