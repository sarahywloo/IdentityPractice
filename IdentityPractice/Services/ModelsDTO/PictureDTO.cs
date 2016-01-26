using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Services.ModelsDTO {
    public class PictureDTO {

        public ApplicationUserDTO Owner { get; set; }
        public string Url { get; set; }
    }
}