using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public Guid Author { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Title post cannot be greater than 40 characters.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(8000)]
        [MinLength(5, ErrorMessage = "Post body must be at least 5 characters")]
        public string Text { get; set; }

        //Foreign Key
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
