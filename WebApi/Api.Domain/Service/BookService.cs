using Api.Database.Entity;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Domain.IService;
using Api.Repository.IRepository;
using AutoMapper;

namespace Api.Domain.Service
{
    public class BookService : Service<IBookRepository, Book, BookDto, int>, IBookService
    {
        public BookService(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
