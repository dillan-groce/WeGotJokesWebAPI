using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Models.AnimalJoke
{
    public class AnimalJokeListItem
    {
        public int AnimalJokeId { get; set; }
        public string Punchline { get; set; }
        [Display(Name = "Joke Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
