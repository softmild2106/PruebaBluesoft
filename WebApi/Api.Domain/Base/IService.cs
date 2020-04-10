using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Base
{
    public interface IService<TRepository, TEntity, TDto, TKey>
    {
        TRepository Repository { get; }
        IMapper Mapper { get; }
        DataTransferObject<TDto> FindById(TKey id);
        DataTransferObject<IEnumerable<TDto>> Find(Expression<Func<TEntity, bool>> predicate);
        DataTransferObject<IEnumerable<TDto>> FindAll();
        DataTransferObject<TDto> Create(TDto dtoObject);
        DataTransferObject<TDto> Update(TDto dtoObject);
        void Delete(TKey id);

    }
}
