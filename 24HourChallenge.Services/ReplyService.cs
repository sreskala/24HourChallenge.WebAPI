using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using System.Collections.Generic;
using System.Linq;

namespace _24HourChallenge.Services
{
    public class ReplyService
    {

        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(CreateReply model)
        {
            var entity =
                new Reply()
                {
                    Author = _userId,
                    Text = model.Text,
                    CommentId = model.CommentId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
