﻿using Api.Database.Entity;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Repository.IRepository;
using System.Collections.Generic;

namespace Api.Domain.IService
{
    public interface IBookService : IService<IBookRepository, Book, BookDto, int>
    {
        DataTransferObject<IEnumerable<BookDto>> GetBookListWithFilter(BookFilterDto filterDto);
    }
}
