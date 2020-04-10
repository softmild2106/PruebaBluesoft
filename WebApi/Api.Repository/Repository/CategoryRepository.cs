using Api.Database.Data;
using Api.Database.Entity;
using Api.Repository.Base;
using Api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Repository
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApiContext context) : base(context)
        {
            
        }
        
    }
}
