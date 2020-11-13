using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public Guid Author { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(Comment))]
        [Required]
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
