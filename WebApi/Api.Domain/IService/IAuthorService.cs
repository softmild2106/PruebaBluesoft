using Api.Database.Entity;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.IService
{
    public interface IAuthorService : IService<IAuthorRepository,Author, AuthorDto, int>
    {
    }
}
