using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dto
{
    public class BookFilterDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public SearchType SearchType { get; set; }
    }

    public enum SearchType
    {
        Name = 1,
        Category = 2,
        Author = 3
    }
}
