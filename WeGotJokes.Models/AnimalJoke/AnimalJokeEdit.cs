using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Models.AnimalJoke
{
    public class AnimalJokeEdit
    {
        public int AnimalJokeId { get; set; }
        public string Punchline { get; set; }
        public bool Clean { get; set; }
    }
}
