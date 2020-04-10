using Api.Database.Data;
using Api.Database.Entity;
using Api.Repository.Base;
using Api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Repository
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(ApiContext context) : base(context)
        {

        }
    }
}
