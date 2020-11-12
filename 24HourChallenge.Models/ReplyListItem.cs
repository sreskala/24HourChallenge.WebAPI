using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class ReplyListItem
    {
        public int CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public virtual CommentListItem Comment { get; set; }

        public Guid Author { get; set; }

        public string Text { get; set; }

    }
}
