using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Data
{
    public class Rating
    {
        public int RatingId { get; set; }
        public double StarCount { get; set; }
        public int OwnerId { get; set; }

        [ForeignKey("DadJoke")]
        public int DadJokeId { get; set; }
        public virtual DadJoke DadJoke { get; set; }

        [ForeignKey("AnimalJoke")]
        public int AnimalJokeId { get; set; }
        public virtual AnimalJoke AnimalJoke { get; set; }
    }
}
