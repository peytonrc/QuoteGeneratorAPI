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

        public IEnumerable<UserRatingQuoteListItem> GetCategoryRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userRatingsQuery =
                    ctx
                        .UserRatingQuotes                     
                        .Select(e => new UserRatingQuoteListItem
                        {
                            UserRatingQuoteId = e.UserRatingQuoteId,
                            QuoteId = e.QuoteId,
                            UserId = e.UserId,
                            UserRating = e.UserRating,
                            CategoryId = e.Quote.CategoryId,
                        }) ;

                return userRatingsQuery.ToList();
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

        public int GetBestCategory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var catList = GetUserRatingQuotes();
                var banana = catList.GroupBy(x => x.CategoryId)
                    .OrderByDescending(x => x.Count())
                    .First().Key;
                return banana;
            }
        }

        public List<UserRatingQuoteListItem> GetUserRatingQuotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userRatingsQuery =
                    ctx
                        .UserRatingQuotes
                        .Select(e => new UserRatingQuoteListItem
                        {
                            UserRating = e.UserRating,
                            CategoryId = e.Quote.CategoryId
                        });

                return userRatingsQuery.ToList();
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
