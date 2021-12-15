using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Data
{
    public abstract class Joke
    {
        [Required]
        public Guid JokeCreator { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        
          
        public DateTimeOffset? ModifiedUTC { get; set; }
        
        [Required]
        public bool Clean { get; set; }

        [Required]
        public string Punchline { get; set; }
    }
}
