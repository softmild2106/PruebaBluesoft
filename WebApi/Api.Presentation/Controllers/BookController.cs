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
    public class BookController : ControllerBase
    {
        private IBookService service;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookService service, ILogger<BookController> logger)
        {
            _logger = logger;
            this.service = service;
        }
        // GET: api/Book
        [HttpGet]
        public DataTransferObject<IEnumerable<BookDto>> Get()
        {
            try
            {
                return service.FindAll();
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<IEnumerable<BookDto>>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }

        }

        [HttpGet("GetBookList")]
        public DataTransferObject<IEnumerable<BookDto>> GetBookListWithFilter(BookFilterDto filterDto)
        {
            try
            {
                return service.FindAll();
            }
            catch (ArgumentException ex)
            {                
                _logger.LogError(ex.ToString());
                var resultException = new DataTransferObject<IEnumerable<BookDto>>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<IEnumerable<BookDto>>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }

        }

        // POST: api/Book
        [HttpPost]
        public DataTransferObject<BookDto> Post([FromBody] BookDto book)
        {

            try
            {
                return service.Create(book);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, JsonConvert.SerializeObject(book), ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<BookDto>(book, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
        }

        // PUT: api/Book/5
        [HttpPost("{id}")]
        public DataTransferObject<BookDto> Update(int id, [FromBody] BookDto book)
        {
            try
            {
                return service.Update(book);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, JsonConvert.SerializeObject(book), ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<BookDto>(book, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public DataTransferObject<BookDto> Delete(int id)
        {
            try
            {
                return service.Delete(id);
            }
            catch (Exception ex)
            {
                var logerror = string.Format(LOG_ERROR_WITH_REQUEST_DATA, id, ex.ToString());
                _logger.LogError(logerror);
                var resultException = new DataTransferObject<BookDto>(null, HttpStatusCode.BadRequest, ex.ToString());
                return resultException;
            }
        }
    }
}
