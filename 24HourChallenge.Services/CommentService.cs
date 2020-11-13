using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _24HourChallenge.Services
{
    public class CommentService
    {

        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Author = _userId,
                    Text = model.Text,
                    PostId = model.PostId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetCommentsByPostId(int id)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.PostId == id)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Text = e.Text,
                                    Replies = ctx.Replies.Where(r => r.CommentId == e.CommentId).Select(r =>
                               new ReplyListItem
                               {
                                   ReplyId = r.ReplyId,
                                   Text = r.Text
                               }).ToList()
                                }).ToList();
                return query.ToArray();
            }
        }


        public bool UpdateComment([FromUri]int id, [FromBody] CommentEdit model)//put
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.Author == _userId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        //UPDATE COMMENT BY ID

        public bool UpdateCommentById([FromUri] int id, [FromBody] CommentEdit model)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.Author == _userId);
                entity.Text = model.Text;
                return ctx.SaveChanges() == 1;

            }
        }

        //DELETE COMMENT BY ID

        public bool DeleteCommentsById([FromUri] int id)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.Author == _userId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
