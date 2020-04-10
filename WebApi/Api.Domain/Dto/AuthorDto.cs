using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
