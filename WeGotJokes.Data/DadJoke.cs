using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Data
{
   public class DadJoke : Joke
    {
        [Key]
        public int DadJokeId { get; set; }
        public virtual List<Rating> Ratings { get; set; }

        //public int MyProperty { get; set; }
    }
}
