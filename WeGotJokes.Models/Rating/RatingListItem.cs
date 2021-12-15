using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Models.Rating
{
    public class RatingListItem
    {
        public int RatingId { get; set; }

        [Range(0, 5, ErrorMessage = "Please choose a number between 1 and 5")]
        public double StarCount { get; set; }

        [ForeignKey("DadJoke")]
        public int DadJokeId { get; set; }

        [ForeignKey("AnimalJoke")]
        public int AnimalJokeId { get; set; }
    }
}
