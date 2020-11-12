using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public Guid Author { get; set; }

        [Required]
        public string Text { get; set; }

        ////Foreign Key
        //[ForeignKey(nameof(Reply))]
        //public int ReplyId { get; set; }
        //public virtual List<Reply> Replies { get; set; }
    }
}
