using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Data
{
    public class AnimalJoke : Joke
    {
        [Key]
        public int AnimalJokeId { get; set; }

        public virtual List<Rating> Ratings { get; set; }
    }
}
