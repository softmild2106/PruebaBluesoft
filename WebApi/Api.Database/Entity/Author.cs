using Api.Database.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Entity
{
    public class Author : EntityBase<int>
    {
        
        [Required, StringLength(50)]
        public string Name { get; set; }        
        [Required, StringLength(50)]
        public string LastName { get; set; }
        public string FullName { get { return $"{Name} {LastName}"; } }
        [Required]
        public DateTime DateBirth { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
