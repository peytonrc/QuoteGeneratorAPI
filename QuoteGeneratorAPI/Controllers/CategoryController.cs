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
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService() => new CategoryService(Guid.Parse(User.Identity.GetUserId()));
        public IHttpActionResult GetAll()
        {
            var categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

        public IHttpActionResult Get(int id)
        {
            var service = CreateCategoryService();
            var category = service.GetCategoryById(id);
            return Ok(category);
        }

        [HttpGet]
        [Route("Ratings")]
        public IHttpActionResult GetNumberOfRatingsForCategory()
        {
            var service = CreateCategoryService();
            var category = service.GetCategoryRatings();
            return Ok(category);
        }

        [HttpGet]
        [Route("GetBestCategory")]
        public IHttpActionResult GetBestCategoryByNumberOfRatings()
        {
            var service = CreateCategoryService();
            var category = service.GetBestCategory();
            return Ok(category);
        }

        public IHttpActionResult Post(CategoryCreate category)
        {
            if (category == null)
                return BadRequest("Model cannot be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CategoryEdit category)
        {
            if (category == null)
                return BadRequest("Model cannot be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }
    }
}
