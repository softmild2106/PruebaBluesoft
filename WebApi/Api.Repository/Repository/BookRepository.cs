using Api.Database.Data;
using Api.Database.Entity;
using Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Repository
{
    public class BookRepository : Repository<Book, int>
    {
        public BookRepository(ApiContext context) : base(context)
        {

        }
    }
}
