using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeGotJokes.Data;
using WeGotJokes.Models.DadJoke;

namespace WeGotJokes.Services
{
    public class DadJokeService
    {
        private readonly Guid _userId;

        public DadJokeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDadJoke(DadJokeCreate model)
        {
            var entity =
                        new DadJoke()
                        {
                            JokeCreator = _userId,
                            Punchline = model.Punchline,
                            Clean =model.Clean,
                            CreatedUTC = DateTimeOffset.Now
                        };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DadJokes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DadJokeListItem> GetDadJokes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                        ctx
                            .DadJokes
                            .Where(e => e.JokeCreator == _userId)
                            .Select(
                                e =>
                                    new DadJokeListItem
                                    {
                                        DadJokeId = e.DadJokeId,
                                        Punchline = e.Punchline,
                                        Clean = e.Clean,
                                        CreatedUtc = e.CreatedUTC
                                    }
                                );

                return query.ToArray();
            }
        }

        public DadJokeDetail GetDadJokeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DadJokes
                        .Single(e => e.DadJokeId == id && e.JokeCreator == _userId);
                return
                    new DadJokeDetail
                    {
                        DadJokeId = entity.DadJokeId,
                        Clean = entity.Clean,
                        CreatedUtc = entity.CreatedUTC,
                        ModifiedUtc = entity.ModifiedUTC,
                        Punchline = entity.Punchline
                    };
            }
        }

        public bool UpdateDadJoke(DadJokeEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DadJokes
                        .Single(e => e.DadJokeId == model.DadJokeId && e.JokeCreator == _userId);

                entity.Punchline = model.Punchline;
                entity.Clean = model.Clean;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDadJoke(int dadJokeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DadJokes
                        .Single(e => e.DadJokeId == dadJokeId && e.JokeCreator == _userId);

                ctx.DadJokes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
