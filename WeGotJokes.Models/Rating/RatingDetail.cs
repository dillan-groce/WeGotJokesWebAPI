using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Models.Rating
{
    public class RatingDetail
    {
        public int RatingId { get; set; }
        public double StarCount { get; set; }

        [ForeignKey("DadJoke")]
        public int? DadJokeId { get; set; }

        [ForeignKey("AnimalJoke")]
        public int? AnimalJokeId { get; set; }
    }
}
