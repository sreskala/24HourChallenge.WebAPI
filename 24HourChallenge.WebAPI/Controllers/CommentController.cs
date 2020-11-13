using _24HourChallenge.Data;
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
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //private method to create a comment service
        private CommentService CreateCommentService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            CommentService commentService = new CommentService(userId);
            return commentService;
        }

        //CRUD METHODS

        //========CREATE========//

        //POST
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //instantitate service
            CommentService service = CreateCommentService();

            if (!service.CreateComment(comment))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //=========Read===========//
        //GET ALL
        //public IHttpActionResult Get()
        //{
        //    CommentService service = CreateCommentService();

        //    IEnumerable<CommentListItem> comments = service.GetComments();

        //    return Ok(comments);
        //}

        ////GET BY ID
        public IHttpActionResult GetByPostId(int id)
        {
            CommentService service = CreateCommentService();

            IEnumerable<CommentListItem> comments = service.GetCommentsByPostId(id);

            return Ok(comments);
        }

        //UPDATE

        [HttpPut]
        public async Task<IHttpActionResult> UpdateComment([FromUri] int id, [FromBody] CommentEdit model)
        {
            var service = CreateCommentService();

            if (!service.UpdateCommentById(id, model)) { return InternalServerError(); }

            return Ok();

        }

        //DELETE

        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {

            var service = CreateCommentService();

            if (!service.DeleteCommentsById(id)) { return InternalServerError(); }

            return Ok();

        }
    }
}
