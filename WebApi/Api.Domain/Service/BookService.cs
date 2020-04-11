using Api.Database.Entity;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Domain.IService;
using Api.Repository.IRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Api.Common.Constants;

namespace Api.Domain.Service
{
    public class BookService : Service<IBookRepository, Book, BookDto, int>, IBookService
    {
        public BookService(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
            
        }

        public DataTransferObject<IEnumerable<BookDto>> GetBookListWithFilter(BookFilterDto filterDto)
        {
            Expression<Func<Book, bool>> whereExpression;
            switch (filterDto.SearchType)
            {
                case SearchType.Name:
                    if(string.IsNullOrEmpty(filterDto.Name))
                        throw new ArgumentException(BOOK_NAME_NULL_OR_EMPTY, "Name");
                    whereExpression = (b => b.BookName.Contains(filterDto.Name));
                    break;
                case SearchType.Category:
                    whereExpression = (b => b.CategoryId == filterDto.CategoryId);
                    break;
                case SearchType.Author:
                    whereExpression = (b => b.AuthorId == filterDto.AuthorId);
                    break;
                default:
                    whereExpression = (b => true);
                    break;
            }
            var result = Find(whereExpression);
            return result;
        }
    }
}
