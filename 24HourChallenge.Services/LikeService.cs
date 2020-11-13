using System;
using _24HourChallenge.Models;
using _24HourChallenge.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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

        //LIKE DELETE

        public bool DeleteLikeById([FromUri] int id)//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeId == id && e.Author == _userId);
                ctx.Likes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLikeByPostId([FromUri] int id)
        {
            using(var context = new ApplicationDbContext())
            {
                var entityList =
                    context
                    .Likes
                    .Where(e => e.PostId == id && e.Author == _userId)
                    .ToList();

                if(entityList.Count == 0)
                {
                    return false;
                }

                int listLength = entityList.Count();
                Random random = new Random();
                int randLike = random.Next(0, listLength);
                Like likeToBeDeleted = entityList[randLike];

                context.Likes.Remove(likeToBeDeleted);
                return context.SaveChanges() == 1;
            }
        }
    }
}
