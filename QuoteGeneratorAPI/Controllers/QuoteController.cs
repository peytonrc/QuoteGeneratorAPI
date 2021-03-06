﻿using Microsoft.AspNet.Identity;
using QuoteGenerator.Models.QuoteModels;
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
    [RoutePrefix("api/Quote")]
    public class QuoteController : ApiController
    {
        private QuoteService CreateQuoteService() => new QuoteService(Guid.Parse(User.Identity.GetUserId()));
        public IHttpActionResult GetAll()
        {
            var quoteService = CreateQuoteService();
            var quotes = quoteService.GetQuotes();
            return Ok(quotes);
        }
        public IHttpActionResult Get(int id)
        {
            var service = CreateQuoteService();
            var quotes = service.GetQuoteById(id);
            return Ok(quotes);
        }

        [HttpGet]
        [Route("ByAuthor/{id}")]
        public IHttpActionResult GetByAuthorId(int id)
        {
            var service = CreateQuoteService();
            var quotes = service.GetQuotesByAuthorId(id);
            return Ok(quotes);
        }

        [HttpGet]
        [Route("ByCategory/{id}")]
        public IHttpActionResult GetByCategoryId(int id)
        {
            var service = CreateQuoteService();
            var quotes = service.GetQuotesByCategoryId(id);
            return Ok(quotes);
        }

        [HttpGet]
        [Route("ByRandom")]
        public IHttpActionResult GetByRandom()
        {
            var service = CreateQuoteService();
            var quotes = service.GetRandomQuote();
            return Ok(quotes);
        }

        public IHttpActionResult Post(QuoteCreate quote)
        {
            if (quote == null)
                return BadRequest("Received model was null.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateQuoteService();
            if (!service.CreateQuote(quote))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(QuoteEdit quote)
        {
            if (quote == null)
                return BadRequest("Received model was null.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateQuoteService();
            if (!service.UpdateQuote(quote))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateQuoteService();
            if (!service.DeleteQuote(id))
                return InternalServerError();
            return Ok();
        }
    }
}
