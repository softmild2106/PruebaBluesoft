using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Base;
using Api.Domain.Dto;
using Api.Domain.IService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService service;
        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }
        // GET: api/Author
        [HttpGet]
        public DataTransferObject<IEnumerable<AuthorDto>> Get()
        {
            return service.FindAll();
        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Author
        [HttpPost]
        public DataTransferObject<AuthorDto> Post([FromBody] AuthorDto author)
        {
            return service.Create(author);
        }

        // PUT: api/Author/5
        [HttpPost("{id}")]
        public DataTransferObject<AuthorDto> Update(int id, [FromBody] AuthorDto author)
        {
            return service.Update(author);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
