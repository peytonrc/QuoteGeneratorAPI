using QuoteGenerator.Data;
using QuoteGenerator.Models;
using QuoteGenerator.Models.UserRatingQuoteModels;
using QuoteGeneratorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;
        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public int GetCategoryRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userRatingsQuery =
                    ctx
                        .UserRatingQuotes                     
                        .Select(e => new UserRatingQuoteListItem
                        {
                            //CategoryId = e.Quote.Category.CategoryId,
                            UserRating = e.UserRating,
                        }) ;

                return userRatingsQuery.Count();
            }
        }

        






        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var categoryQuery =
                    ctx
                        .Categories
                        .Select(e => new CategoryListItem
                        {
                            CategoryId = e.CategoryId,
                            Name = e.Name,

                        });

                return categoryQuery.ToArray();
            }
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category
            {
                Name = model.Name,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CategoryDetail GetCategoryById(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.SingleOrDefault(e => e.CategoryId == categoryId);

                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        Name = entity.Name,

                    };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .SingleOrDefault(e => e.CategoryId == model.CategoryId);

                entity.CategoryId = model.CategoryId;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .SingleOrDefault(e => e.CategoryId == categoryId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
