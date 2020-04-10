using Api.Database.Entity;
using Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.IRepository
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
    }
}
