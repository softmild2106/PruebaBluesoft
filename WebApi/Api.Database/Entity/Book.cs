using Api.Database.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Entity
{
    public class Book : EntityBase<int>
    {
        [Required, StringLength(100)]
        public string BookName { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required, StringLength(13)]
        public string ISBN { get; set; }
    }
}
