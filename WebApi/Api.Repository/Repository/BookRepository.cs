using Api.Database.Data;
using Api.Database.Entity;
using Api.Repository.Base;
using Api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Repository
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(ApiContext context) : base(context)
        {

        }
    }
}
