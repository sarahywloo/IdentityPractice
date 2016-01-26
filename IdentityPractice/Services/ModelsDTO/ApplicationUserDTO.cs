using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Services.ModelsDTO {
    public class ApplicationUserDTO {

        public IList<ApplicationUserDTO> Following { get; set; }
        public IList<ApplicationUserDTO> Followers { get; set; }
        public string UserName { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}