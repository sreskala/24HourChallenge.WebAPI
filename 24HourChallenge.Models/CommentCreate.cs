using _24HourChallenge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(8000)]
        [MinLength(5, ErrorMessage = "Post body must be at least 5 characters")]
        public string Text { get; set; }
        
        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId  {get; set; }
    }
}
