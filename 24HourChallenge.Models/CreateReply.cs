using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class CreateReply
    {
        [Required]
        public string Text { get; set; }


        [ForeignKey(nameof(CommentId))]
        public int CommentId { get; set; }





    }
}
