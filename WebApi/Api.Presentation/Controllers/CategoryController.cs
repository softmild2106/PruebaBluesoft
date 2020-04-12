using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Domain.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static Api.Common.Constants;

namespace Api.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService service;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            _logger = logger;
            this.service = service;
        }
        // GET: api/Category
        [HttpGet]
        public DataTransferObject<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                return service.FindAll();
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<IEnumerable<CategoryDto>>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }

        }
        [HttpGet("{id}")]
        public DataTransferObject<CategoryDto> GetCategoryById(int id)
        {
            try
            {
                return service.FindById(id);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<CategoryDto>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }

        }
        // POST: api/Category
        [HttpPost]
        public DataTransferObject<CategoryDto> Post([FromBody] CategoryDto category)
        {

            try
            {
                return service.Create(category);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, JsonConvert.SerializeObject(category), ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<CategoryDto>(category, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
        }

        // PUT: api/Category/5
        [HttpPost("{id}")]
        public DataTransferObject<CategoryDto> Update(int id, [FromBody] CategoryDto category)
        {
            try
            {
                category.Id = id;
                return service.Update(category);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, JsonConvert.SerializeObject(category), ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<CategoryDto>(category, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public DataTransferObject<CategoryDto> Delete(int id)
        {
            try
            {
                return service.Delete(id);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, id, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<CategoryDto>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
        }
    }
}
