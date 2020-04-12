using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Domain.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static Api.Common.Constants;

namespace Api.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService service;
        private readonly ILogger<AuthorController> _logger;
        public AuthorController(IAuthorService service, ILogger<AuthorController> logger)
        {
            _logger = logger;
            this.service = service;
        }
        // GET: api/Author
        [HttpGet]
        public DataTransferObject<IEnumerable<AuthorDto>> Get()
        {
            try
            {
                return service.FindAll();
            }
            catch(Exception ex)
            {
                var logerror = string.Format(LOG_ERROR, ex.ToString());
                _logger.LogError(logerror);
                var resultException =  new DataTransferObject<IEnumerable<AuthorDto>>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
            
        }
        [HttpGet("{id}")]
        public DataTransferObject<AuthorDto> GetAuthorById(int id)
        {
            try
            {
                return service.FindById(id);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<AuthorDto>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }

        }
        // POST: api/Author
        [HttpPost]
        public DataTransferObject<AuthorDto> Post([FromBody] AuthorDto author)
        {
            
            try
            {
                return service.Create(author);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, JsonConvert.SerializeObject(author), ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<AuthorDto>(author, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
        }

        // PUT: api/Author/5
        [HttpPost("{id}")]
        public DataTransferObject<AuthorDto> Update(int id, [FromBody] AuthorDto author)
        {
            try
            {
                return service.Update(author);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, JsonConvert.SerializeObject(author), ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<AuthorDto>(author, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public DataTransferObject<AuthorDto> Delete(int id)
        {            
            try
            {
                return service.Delete(id);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, id, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<AuthorDto>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
        }
    }
}
