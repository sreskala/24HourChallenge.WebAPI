﻿using _24HourChallenge.Models;
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
    public class CommentController : ApiController
    {
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
        //    //CommentService service = CreateCommentService();

        //    //IEnumerable<CommentListItem> comments = service.GetComments();

        //    //return Ok(comments);
        //}

        ////GET BY ID
        //public IHttpActionResult Get(int id)
        //{
        //    //CommentService service = CreateCommentService();

        //    //CommentDetail comment = service.GetCommentById(id);

        //    //return Ok(comment);
        //}


    }
}