﻿using Api.Database.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Entity
{
    public class Category : EntityBase<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
