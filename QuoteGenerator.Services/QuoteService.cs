using QuoteGenerator.Data;
using QuoteGenerator.Models.QuoteModels;
using QuoteGeneratorAPI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Services
{
    public class QuoteService
    {
        private readonly Guid _userId;

        public QuoteService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<QuoteListItem> GetQuotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quoteQuery =
                    ctx
                        .Quotes
                        .Select(e => new QuoteListItem
                        {
                            QuoteId = e.QuoteId,
                            Content = e.Content,
                            AuthorId = e.AuthorId,
                            AuthorName = e.Author.Name,
                            CategoryId = e.CategoryId,
                            CategoryName = e.Category.Name,
                            DateSpoken = e.DateSpoken
                        });

                return quoteQuery.ToArray();
            }
        }
        public bool CreateQuote(QuoteCreate model)
        {
            var entity = new Quote
            {
                Content = model.Content,
                AuthorId = model.AuthorId,
                CategoryId = model.CategoryId,
                DateSpoken = model.DateSpoken
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Quotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public QuoteDetail GetQuoteById(int quoteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Quotes.SingleOrDefault(e => e.QuoteId == quoteId);

                return
                    new QuoteDetail
                    {
                        QuoteId = entity.QuoteId,
                        Content = entity.Content,
                        AuthorId = entity.AuthorId,
                        AuthorName = entity.Author.Name,
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.Category.Name,
                        DateSpoken = entity.DateSpoken,
                        AverageRating = AverageRating(entity.UserRatingQuotes)
                        //Call a method that takes in a list of UserRatingQuotes, averages the rating and returns that averaged rating
                    };
            }
        }

        public double AverageRating(List<UserRatingQuote> list)
        {
            double avgRating = 0;
            foreach (var rating in list)
            {
                avgRating += rating.UserRating;
            }
            return (list.Count > 0) ? Math.Round(avgRating / list.Count, 2) : 0;
        }

        public bool UpdateQuote(QuoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Quotes
                        .SingleOrDefault(e => e.QuoteId == model.QuoteId);

                entity.Content = model.Content;
                entity.DateSpoken = model.DateSpoken;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteQuote(int quoteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Quotes
                        .SingleOrDefault(e => e.QuoteId == quoteId);

                ctx.Quotes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
