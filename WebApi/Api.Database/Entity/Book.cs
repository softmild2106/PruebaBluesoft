using Api.Database.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity
{
    public class Book : EntityBase<int>
    {
        [Required, StringLength(100)]
        public string BookName { get; set; }
        [Required]
        [ForeignKey("Standard")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Required]
        [ForeignKey("Standard")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required, StringLength(13)]
        public string ISBN { get; set; }

    }
}
