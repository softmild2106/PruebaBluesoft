using Api.Database.Entity;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Repository.IRepository;

namespace Api.Domain.IService
{
    public interface ICategoryService : IService<ICategoryRepository, Category, CategoryDto, int>
    {
    }
}
