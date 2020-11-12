using _24HourChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24HourChallenge.Models;

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
                new PostCreate()
                {
                    Title = model.Title,
                    Text = model.Text,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Post.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
