using IdentityPractice.Infrastructure;
using IdentityPractice.Services.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Services {
    public class FriendService {

        private UserRepository _userRepo;

        public FriendService(UserRepository userRepo) {
            _userRepo = userRepo;
        }

        public IList<ApplicationUserDTO> FriendsList(string currentUser) {
            var followings = _userRepo.GetFollowings(currentUser);;
            return (from u in followings
                              select new ApplicationUserDTO() {
                                  UserName = u.UserName,
                                  ProfilePictureUrl = u.ProfilePicture.Url
                              }).ToList();
        }
    }
}