using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Data
{
    public abstract class Joke
    {// If an error code still persist it might be wise to change the Guid type into an int and vis versa for AnimalJoke and DadJoke.

     // Not 100% certain if this will work. 
        [Required]
        public Guid JokeCreator { get; set; } // public int JokeCreator {get; set;}
        
        
        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        
          
        public DateTimeOffset? ModifiedUTC { get; set; }
        
        [Required]
        public bool Clean { get; set; }

        [Required]
        public string Punchline { get; set; }
    }
}
