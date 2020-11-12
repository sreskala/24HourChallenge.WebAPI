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
        public string Text { get; set; }
        
   
        [ForeignKey(nameof(Post))]
        public int PostId  {get; set; }










}
}
