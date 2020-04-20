using Api.Database.Base;
using Api.Database.Entity;
using Api.Domain.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Api.Domain
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            var assemblyDatabase = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "Api.Database").FirstOrDefault();
            var dtoList = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "Api.Domain").FirstOrDefault().GetTypes().Where(x => x.Name.EndsWith("Dto"));
            foreach (var dto in dtoList)
            {
                var nameDto = dto.Name;
                var idx = nameDto.LastIndexOfAny("Dto".ToArray());
                var nameEntity = nameDto.Remove(idx - 2,3);
                var entity = assemblyDatabase.GetTypes().Where(a => a.Name == nameEntity).FirstOrDefault();
                if (entity != null)
                {
                    CreateMap(entity, dto).ReverseMap();
                }                
            }
        }

    }
}
