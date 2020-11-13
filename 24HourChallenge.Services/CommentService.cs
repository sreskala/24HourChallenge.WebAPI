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
                        .Where(e => e.PostId == id && e.Author == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Text = e.Text,
                                    //Comments = e.Comments
                                }
                        );
                return query.ToArray();
            }
        }


        public IEnumerable<ReplyListItem> GetReplyByCommentId(int id)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.CommentId == id && e.Author == _userId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    Author = e.Author,
                                    Text = e.Text,
                                    //Comments = e.Comments
                                }
                        );
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

    }
}
