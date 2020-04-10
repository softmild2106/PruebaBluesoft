using Api.Database.Entity;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Domain.IService;
using Api.Repository.IRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Service
{
    public class AuthorService : Service<IAuthorRepository, Author, AuthorDto, int>, IAuthorService
    {
        public AuthorService(IAuthorRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
