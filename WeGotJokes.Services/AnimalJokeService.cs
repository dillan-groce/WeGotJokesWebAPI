using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeGotJokes.Data;
using WeGotJokes.Models.AnimalJoke;

namespace WeGotJokes.Services
{
    public class AnimalJokeService
    {
        private readonly Guid _userId;
        public AnimalJokeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAnimalJoke(AnimalJokeCreate model)
        {
            var entity = new AnimalJoke()
            {
                JokeCreator = _userId,
                Punchline = model.Punchline,
                Clean = model.Clean,
                CreatedUTC = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.AnimalJokes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AnimalJokeListItem> GetAnimalJokes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .AnimalJokes
                    .Where(e => e.JokeCreator == _userId)
                    .Select(
                        e =>
                        new AnimalJokeListItem
                        {
                            AnimalJokeId = e.AnimalJokeId,
                            Punchline = e.Punchline,
                            Clean = e.Clean,
                            CreatedUtc = e.CreatedUTC
                        }
                        );
                return query.ToArray();
            }
        }

        public AnimalJokeDetail GetAnimalJokeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .AnimalJokes
                    .Single(e => e.AnimalJokeId == id && e.JokeCreator == _userId);
                return
                    new AnimalJokeDetail
                    {
                        AnimalJokeId = entity.AnimalJokeId,
                        Punchline = entity.Punchline,
                        Clean = entity.Clean,
                        CreatedUtc = entity.CreatedUTC,
                    };
            }
        }

        public bool UpdateAnimalJoke(AnimalJokeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .AnimalJokes
                    .Single(e => e.AnimalJokeId == model.AnimalJokeId && e.JokeCreator == _userId);
                entity.Punchline = model.Punchline;
                entity.Clean = model.Clean;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }

        //get random animal joke (is the get animal joke w/out Id (code beginning line 35) already doing that?)
        //public IEnumerable<AnimalJokeListItem> GetRandomAnimalJoke()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .AnimalJokes
        //            .Select(
        //                e =>
        //                new AnimalJokeListItem
        //                {
        //                    AnimalJokeId = e.AnimalJokeId,
        //                    Punchline = e.Punchline,
        //                    Clean = e.Clean
        //                    CreatedUtc = e.CreatedUTC
        //                }
        //                );
        //        return query.ToArray();
        //    }
        //}

        public bool DeleteAnimalJoke(int animalJokeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .AnimalJokes
                    .Single(e => e.AnimalJokeId == animalJokeId && e.JokeCreator == _userId);

                ctx.AnimalJokes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
