using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using System.Collections.Generic;
using System.Linq;

namespace _24HourChallenge.Services
{
    public class LikeService
    {

        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(AddLike model)
        {
            var entity =
                new Like()
                {
                    Author = _userId,
                    PostId = model.PostId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
