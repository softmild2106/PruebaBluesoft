using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
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
