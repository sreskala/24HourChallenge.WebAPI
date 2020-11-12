using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using System.Collections.Generic;
using System.Linq;

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
                                    //Comments = e.Comments
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
                                    //Comments = e.Comments
                                }
                        );
                return query.ToArray();
            }
        }

    }
}
