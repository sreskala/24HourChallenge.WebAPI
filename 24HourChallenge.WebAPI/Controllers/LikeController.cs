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
    public class LikeController : ApiController
    {
        //create private method for newing up service
        private LikeService CreateLikeService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            LikeService likeService = new LikeService(userId);
            return likeService;
        }

        //POST

        public IHttpActionResult Post(AddLike model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LikeService service = CreateLikeService();

            if(!service.CreateLike(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteLikeByPostId(int id)
        {

            var service = CreateLikeService();

            if (!service.DeleteLikeByPostId(id)) { return InternalServerError(); }

            return Ok();

        }


    }
}
