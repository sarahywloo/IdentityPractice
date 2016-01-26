using IdentityPractice.Services;
using IdentityPractice.Services.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdentityPractice.Presentation.Controllers
{
    public class FriendsController : ApiController {

        private FriendService _friendService;

        public FriendsController(FriendService friendService) {
            _friendService = friendService;
        }

        //return a list of friends
        public IList<ApplicationUserDTO> Get() {
            //return _friendService.FriendsList(User.Identity.Name);
            return _friendService.FriendsList("Sarah");
        }

        //search a list of friends based on a search

    }
}
