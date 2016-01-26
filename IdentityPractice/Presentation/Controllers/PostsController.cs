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
    public class PostsController : ApiController {

        private PostService _postService;

        public PostsController(PostService postService) {
            _postService = postService;
        }
        //return a list of news feed posts
        //the method GetNewsFeed() gets a list of news feed posts
        public IList<PostDTO> Get() {
            //return _postService.GetNewsFeed(User.Identity.Name); //current authenticated user
            return _postService.GetNewsFeed("Sarah");
        }
    }
}
