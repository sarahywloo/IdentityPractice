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

        //Attribute based routing
        [HttpGet]
        [Route("api/posts/{username}")] //when we do not want to use conventional routing: /api/controller/{id}
        //if we want to return good or bad, we need to specify the IHttpActionResult
        //no model binding because parameter is already found in the url
        public IHttpActionResult GetProfile(string username) {

            var posts = _postService.GetPostsForUser(username);

            if(posts != null) {
                return Ok(posts);
            }

            return BadRequest();
        }
    }
}
