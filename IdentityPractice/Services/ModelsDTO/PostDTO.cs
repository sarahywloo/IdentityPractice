using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Services.ModelsDTO {
    public class PostDTO {

        public ApplicationUserDTO Owner { get; set; }

        public IList<string> Categories { get; set; }

        public string Location { get; set; }

        public string PictureUrl { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}