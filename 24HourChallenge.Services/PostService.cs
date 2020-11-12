<<<<<<< HEAD
﻿using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using ElevenNote.Data;
using System.Collections.Generic;
=======
﻿using _24HourChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24HourChallenge.Models;
>>>>>>> c6487b1b1b29d224a71aa2d9d1311ddd2d82e41d

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
                                    Comments = e.Comments
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
