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
    public class PostListItem
    {
        public int PostId { get; set; }

        public Guid Author { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int LikeCount { get; set; }

        public virtual List<CommentListItem> Comments { get; set; }

    }
}
