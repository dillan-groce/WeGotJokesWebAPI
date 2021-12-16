using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeGotJokes.Data;
using WeGotJokes.Models;
using WeGotJokes.Models.Rating;

namespace WeGotJokes.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new Rating()
                {
                    OwnerId = _userId,
                    StarCount = model.StarCount,
                    DadJokeId = model.DadJokeId,
                    AnimalJokeId = model.AnimalJokeId
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ratings
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RatingListItem
                                {
                                    RatingId = e.RatingId,
                                    StarCount = e.StarCount,
                                    DadJokeId = e.DadJokeId,
                                    AnimalJokeId = e.AnimalJokeId
                                }
                        );

                return query.ToArray();
            }
        }

        public RatingDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == id && e.OwnerId == _userId);
                return
                    new RatingDetail
                    {
                        RatingId = entity.RatingId,
                        StarCount = entity.StarCount,
                        DadJokeId = entity.DadJokeId,
                        AnimalJokeId = entity.AnimalJokeId
                    };
            }
        }

        public bool UpdateRating(RatingEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == model.RatingId && e.OwnerId == _userId);

                entity.StarCount = model.StarCount;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int ratingId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == ratingId && e.OwnerId == _userId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
