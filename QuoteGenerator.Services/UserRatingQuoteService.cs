using QuoteGenerator.Data;
using QuoteGenerator.Models.UserRatingQuoteModels;
using QuoteGeneratorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Services
{
    public class UserRatingQuoteService
    {
        private readonly Guid _userId;

        public UserRatingQuoteService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<UserRatingQuoteListItem> GetUserRatingQuotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userRatingQuoteQuery =
                    ctx
                        .UserRatingQuotes
                        .Select(e => new UserRatingQuoteListItem
                        {
                            UserRatingQuoteId = e.UserRatingQuoteId,
                            QuoteId = e.QuoteId,
                            UserId = e.UserId,
                            UserRating = e.UserRating

                        });

                return userRatingQuoteQuery.ToArray();
            }
        }
        public bool CreateUserRatingQuote(UserRatingQuoteCreate model)
        {
            var entity = new UserRatingQuote
            {
                QuoteId = model.QuoteId,
                UserId = model.UserId,
                UserRating = model.UserRating
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserRatingQuotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public UserRatingQuoteDetail GetUserRatingQuoteById(int userRatingQuoteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.UserRatingQuotes.SingleOrDefault(e => e.UserRatingQuoteId == userRatingQuoteId);

                return
                    new UserRatingQuoteDetail
                    {
                        UserRatingQuoteId = entity.UserRatingQuoteId,
                        QuoteId = entity.QuoteId,
                        UserId = entity.UserId,
                        UserRating = entity.UserRating

                    };
            }
        }


        public bool UpdateUserRatingQuote(UserRatingQuoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserRatingQuotes
                        .SingleOrDefault(e => e.UserRatingQuoteId == model.UserRatingQuoteId);

                entity.UserRatingQuoteId = model.UserRatingQuoteId;
                entity.UserRating = model.UserRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserRatingQuote(int userRatingQuoteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserRatingQuotes
                        .SingleOrDefault(e => e.QuoteId == userRatingQuoteId);

                ctx.UserRatingQuotes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
