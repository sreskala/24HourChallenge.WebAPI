using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
        public bool UpdateReply([FromUri] int id, [FromBody] ReplyEdit model)//put
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == id && e.Author == _userId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteRepliesById([FromUri] int id)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == id && e.Author == _userId);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
