using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            /*var assembly = Assembly.LoadFrom("Api.Core.DTO");
                           var entityAssembly = typeof(Dto).Assembly;
                           var modelAssembly = typeof(BaseModel).Assembly;
                           var modelNamespace = modelAssembly.GetTypes().Where(a => a.BaseType == typeof(BaseModel)).FirstOrDefault().Namespace;

                           foreach (var entity in entityAssembly.GetTypes().Where(a => a.BaseType == typeof(BaseEntity)))
                           {
                               var model = modelAssembly.GetType(string.Format("{0}.{1}{2}", modelNamespace, entity.Name, "Model"));
                               if (model != null)
                               {
                                   CreateMap(entity, model);
                                   CreateMap(model, entity);
                               }
                           }*/
        }

    }
}
