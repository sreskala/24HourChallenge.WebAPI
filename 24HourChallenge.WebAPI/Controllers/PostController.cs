using _24HourChallenge.Models;
using _24HourChallenge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _24HourChallenge.WebAPI.Controllers
{
    public class PostController : ApiController
    {
        //private method for instantiating service
        private PostService CreatePostService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            PostService postService = new PostService(userId);
            return postService;
        }

        //CRUD METHODS

        //=====CREATE======//
        
        //Post
        public IHttpActionResult Post(PostCreate post)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //instantiate a service
            PostService service = CreatePostService();

            if(!service.CreatePost(post))
            {
                return InternalServerError();
            }

            return Ok();
        } 

        //=======READ=======//

        //GET ALL POSTS
        public IHttpActionResult Get()
        {
            PostService service = CreatePostService();

            IEnumerable<PostListItem> posts = service.GetPosts();

            return Ok(posts);
        }

        //GET POST BY ID
        public IHttpActionResult GetById(int id)
        {
            PostService service = CreatePostService();

            IEnumerable<PostListItem> posts = service.GetPostsById(id);

            return Ok(posts);
        }
        //UPDATE

        [HttpPut]
        public async Task<IHttpActionResult> UpdatePost([FromUri] int id, [FromBody] PostEdit model)
        {
            var service = CreatePostService();

            if (!service.UpdatePostsById(id, model)) { return InternalServerError(); }

            return Ok();

        }

        //DELETE

        [HttpDelete]
        public IHttpActionResult DeletePost(int id)
        {

            var service = CreatePostService();

            if (!service.DeletePostsById(id)) { return InternalServerError(); }

            return Ok();

        }
    }
}
