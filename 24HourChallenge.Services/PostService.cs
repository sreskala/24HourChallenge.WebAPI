using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _24HourChallenge.Services
{
    public class PostService
    {

        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Author = _userId,
                    Title = model.Title,
                    Text = model.Text,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    Author = e.Author,
                                    Title = e.Title,
                                    Text = e.Text,
                                    LikeCount = ctx.Likes.Where(f => f.PostId == e.PostId).Count(),
                                    Comments = ctx.Comments.Where(c => c.PostId == e.PostId).Select(c =>
                                        new CommentListItem
                                        {
                                            CommentId = c.CommentId,
                                            Text = e.Text,
                                            Replies = ctx.Replies.Where(r => r.CommentId == c.CommentId).Select(r =>
                                                new ReplyListItem
                                                {
                                                    ReplyId = r.ReplyId,
                                                    Text = r.Text
                                                }).ToList()
                                        }).ToList()
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<PostListItem> GetPostsById(int id)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.PostId == id && e.Author == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    Author = e.Author,
                                    Title = e.Title,
                                    Text = e.Text,
                                    LikeCount = ctx.Likes.Where(f => f.PostId == e.PostId).Count(),
                                    Comments = ctx.Comments.Where(c => c.PostId == e.PostId).Select(c =>
                                        new CommentListItem
                                        {
                                            CommentId = c.CommentId,
                                            Text = e.Text,
                                            Replies = ctx.Replies.Where(r => r.CommentId == c.CommentId).Select(r =>
                                                new ReplyListItem
                                                {
                                                    ReplyId = r.ReplyId,
                                                    Text = r.Text
                                                }).ToList()
                                        }).ToList()
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdatePostsById([FromUri] int id, [FromBody] PostEdit model)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == id && e.Author == _userId);
                            entity.Title = model.Title;
                            entity.Text = model.Text;
                return ctx.SaveChanges() == 1; 
            
            }
        }

        public bool DeletePostsById([FromUri] int id)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == id && e.Author == _userId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
