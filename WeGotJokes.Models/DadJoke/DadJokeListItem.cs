using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Models.DadJoke
{
    public class DadJokeListItem
    {
        public int DadJokeId { get; set; }
        public string Punchline { get; set; }
        [Display(Name = "Joke Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
