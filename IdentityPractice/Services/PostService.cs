using IdentityPractice.Infrastructure;
using IdentityPractice.Services.ModelsDTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Services {
    public class PostService {

        private PostRepository _postRepo;
        private ApplicationUserManager _userRepo;

        public PostService(PostRepository postRepo, ApplicationUserManager userRepo) {
            _postRepo = postRepo;
            _userRepo = userRepo;
        }

        /// <summary>
        /// News Feed contains  
        /// all of our posts
        /// and our friends posts
        /// </summary>
        /// <returns>A list of posts</returns>
        public IList<PostDTO> GetNewsFeed(string currentUser) {

            var user = _userRepo.FindByName(currentUser);

            return (from p in _postRepo.GetNewsFeed(user)
                    select new PostDTO() {
                        //making location nullable so we dont have to add anything into the database
                        Location = p.Location?.City + ", " + p.Location?.State,
                        Message = p.Message,
                        CreatedDate = p.CreatedDate,
                        PictureUrl = p.Picture?.Url,
                        Categories = (from c in p.Categories
                                      select c.Name).ToList(),
                        Owner = new ApplicationUserDTO() {
                            UserName = p.Owner.UserName
                        }
                    }
                    ).ToList();
        }
    }
}