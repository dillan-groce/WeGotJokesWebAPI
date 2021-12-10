using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Data
{
    public abstract class Joke
    {
        public Guid JokeCreator { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
        public bool Clean { get; set; }
        public string Punchline { get; set; }
    }
}
