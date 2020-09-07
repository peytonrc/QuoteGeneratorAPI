using Microsoft.AspNet.Identity;
using QuoteGenerator.Models;
using QuoteGenerator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteGeneratorAPI.Controllers
{
    [Authorize]
    public class AuthorController : ApiController
    {
        private AuthorService CreateAuthorService() => new AuthorService(Guid.Parse(User.Identity.GetUserId()));
        public IHttpActionResult GetAll()
        {
            var authorService = CreateAuthorService();
            var authors = authorService.GetAuthors();
            return Ok(authors);
        }
        public IHttpActionResult Get(int id)
        {
            var service = CreateAuthorService();
            var author = service.GetAuthorById(id);
            return Ok(author);
        }
        public IHttpActionResult Post(AuthorCreate author)
        {
            if (author == null)
                return BadRequest("Received model was null.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAuthorService();
            if (!service.CreateAuthor(author))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(AuthorEdit author)
        {
            if (author == null)
                return BadRequest("Received model was null.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAuthorService();
            if (!service.UpdateAuthor(author))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAuthorService();
            if (!service.DeleteAuthor(id))
                return InternalServerError();
            return Ok();
        }
    }
}
