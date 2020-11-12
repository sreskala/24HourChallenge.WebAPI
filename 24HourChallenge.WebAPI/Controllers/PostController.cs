using _24HourChallenge.Models;
using _24HourChallenge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            //get the list of posts here

            //return Ok(posts);
        }

        //GET POST BY ID
        public IHttpActionResult Get(int id)
        {
            PostService service = CreatePostService();

            //get the post by id here with method

            //return Ok(post)
        }

    }
}
