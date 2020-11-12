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
            public int PostId { get; set; }
            [ForeignKey(nameof(PostId))]
            public virtual PostListItem Post { get; set; }

            public Guid Author { get; set; }

            public string Text { get; set; }

            public virtual List<CreateReply> Replies { get; set; }

    }
}
