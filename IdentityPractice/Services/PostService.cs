using IdentityPractice.Infrastructure;
using IdentityPractice.Services.ModelsDTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityPractice.Services {
    public class PostService {

        //Services job is to get the repository to acccess the database
        private PostRepository _postRepo;
        private UserRepository _userRepo;

        public PostService(PostRepository postRepo, UserRepository userRepo) {
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

            var followings = (from u in _userRepo.GetFollowings(currentUser)
                              select u.UserName).ToList();
            //add current user to the list
            followings.Add(currentUser);

            //cannot pass a list into the parameter and so we need to convert it into an array
            return (from p in _postRepo.GetPostsForUsers(followings.ToArray())
                    select new PostDTO() {
                        //making location nullable so we dont have to add anything into the database
                        Location = p.Location.City + ", " + p.Location.State,
                        Message = p.Message,
                        CreatedDate = p.CreatedDate,
                        PictureUrl = p.Picture.Url,
                        Categories = (from c in p.Categories
                                      select c.Name).ToList(),
                        Owner = new ApplicationUserDTO() {
                            UserName = p.Owner.UserName
                        }
                    }).ToList();
        }

        public IList<PostDTO> GetPostsForUser(string userName) {

            if(_userRepo.DoesUserExist(userName)) {
                return (from p in _postRepo.GetPostsForUsers(userName)
                        select new PostDTO() {
                            Location = p.Location.City + ", " + p.Location.State,
                            Message = p.Message,
                            CreatedDate = p.CreatedDate,
                            PictureUrl = p.Picture.Url,
                            Categories = (from c in p.Categories
                                          select c.Name).ToList(),
                            Owner = new ApplicationUserDTO() {
                                UserName = p.Owner.UserName
                            }
                            }).ToList();
            }

            return null;
        }
    }
}