using _24HourChallenge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        public virtual List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
