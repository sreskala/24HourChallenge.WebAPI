﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [Required]
        public Guid Author { get; set; }

        [ForeignKey(nameof(Post))]
        [Required]
        public int PostId { get; set; }


        ////Foreign Key
        //public virtual List<Reply> Replies { get; set; }
    }
}