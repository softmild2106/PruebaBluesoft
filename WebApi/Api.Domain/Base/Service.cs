using Api.Database.Base;
using Api.Repository.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Base
{
    public class Service<TRepository, TEntity, TDTO, TKey> : IService<TRepository, TEntity, TDTO, TKey>
     where TEntity : EntityBase<TKey>
     where TRepository : IRepository<TEntity, TKey>
     where TKey : IEquatable<TKey>
    {
        public Service(TRepository repository, IMapper mapper)         
        {
            Repository = repository;
            Mapper = mapper;
        }

        public TRepository Repository { get; }
        public IMapper Mapper { get; }
        public TEntity ConvertToEntity(TDTO source) => Mapper.Map<TEntity>(source);
        public TDTO ConvertToDto(TEntity source) => Mapper.Map<TDTO>(source);
        public IEnumerable<TDTO> ConvertToEnumerableDto(IEnumerable<TEntity> source) => Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDTO>>(source);
        public DataTransferObject<TDTO> Create(TDTO dtoObject)
        {
            TEntity entity = ConvertToEntity(dtoObject);
            Repository.Add(entity);
            var response = new DataTransferObject<TDTO>(dtoObject);
            return response;
        }

        public DataTransferObject<TDTO> Delete(TKey id)
        {
            TEntity entity = Repository.GetById(id);
            var response = Repository.Delete(entity);
            return new DataTransferObject<TDTO>(ConvertToDto(response));
        }

        public DataTransferObject<IEnumerable<TDTO>> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var response = Repository.List(predicate);
            return new DataTransferObject<IEnumerable<TDTO>>(ConvertToEnumerableDto(response));
        }

        public DataTransferObject<IEnumerable<TDTO>> FindAll()
        {
            var response = Repository.List();
            return new DataTransferObject<IEnumerable<TDTO>>(ConvertToEnumerableDto(response));
        }

        public DataTransferObject<TDTO> FindById(TKey id)
        {   
            var response = new DataTransferObject<TDTO>(ConvertToDto(Repository.GetById(id)));
            return response;
        }

        public DataTransferObject<TDTO> Update(TDTO dtoObject)
        {
            TEntity entity = ConvertToEntity(dtoObject);
            Repository.Update(entity);
            var response = new DataTransferObject<TDTO>(dtoObject);
            return response;
        }
    }
}
