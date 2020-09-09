using Microsoft.AspNet.Identity;
using QuoteGenerator.Data;
using QuoteGenerator.Models.UserRatingQuoteModels;
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
    public class UserRatingQuoteController : ApiController
    {
        private UserRatingQuoteService CreateUserRatingQuoteService() => new UserRatingQuoteService(Guid.Parse(User.Identity.GetUserId()));
        public IHttpActionResult GetAll()
        {
            var userRatingQuoteService = CreateUserRatingQuoteService();
            var userRatingQuotes = userRatingQuoteService.GetUserRatingQuotes();
            return Ok(userRatingQuotes);
        }
        public IHttpActionResult Get(int id)
        {
            var service = CreateUserRatingQuoteService();
            var userRatingQuotes = service.GetUserRatingQuoteById(id);
            return Ok(userRatingQuotes);
        }
        public IHttpActionResult Post(UserRatingQuoteCreate userRatingQuote)
        {
            if (userRatingQuote == null)
                return BadRequest("Received model was null.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateUserRatingQuoteService();
            if (!service.CreateUserRatingQuote(userRatingQuote))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(UserRatingQuoteEdit userRatingQuote)
        {
            if (userRatingQuote == null)
                return BadRequest("Received model was null.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateUserRatingQuoteService();
            if (!service.UpdateUserRatingQuote(userRatingQuote))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserRatingQuoteService();
            if (!service.DeleteUserRatingQuote(id))
                return InternalServerError();
            return Ok("The rating was deleted");
        }
    }
}
