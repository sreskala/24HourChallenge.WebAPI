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

        public int Id { get; set; }

        public string Text { get; set; }
        
        [Required]
        public Guid Author { get; set; }

    
        [ForeignKey(nameof(PostId))]

        public virtual Comment Comment { get; set; }










}
}
