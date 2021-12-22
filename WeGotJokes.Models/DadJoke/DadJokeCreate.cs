using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeGotJokes.Models.DadJoke
{
    public class DadJokeCreate
    {
        [Required]
        [MinLength(5, ErrorMessage = "You need to enter more characters.")]
        public string Punchline { get; set; }
        [Required(ErrorMessage =" You must disclose if this joke is clean or dirty.")]
        public bool Clean { get; set; }
    }
}
