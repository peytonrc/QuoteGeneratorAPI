using QuoteGenerator.Data;
using QuoteGenerator.Models;
using QuoteGeneratorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Services
{
    public class AuthorService
    {

        private readonly string _authorName;
        public AuthorService(string name)
        {
            _authorName = name;
        }

        public IEnumerable<AuthorListItem> GetAuthorQuotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var authorQuery =
                    ctx
                        .Quotes
                        .Where(e => e.Author.Name == _authorName)
                        .Select(
                            e => new AuthorListItem
                            {
                                AuthorId = e.AuthorId,
                                Name = e.Author.Name,
                                BirthDate = e.Author.BirthDate
                            });

                return authorQuery.ToArray();
            }
        }
        public bool CreateAuthor(AuthorCreate model)
        {
            var entity =
                new Author()
                {
                    Name = model.Name,
                    BirthDate = model.BirthDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAuthor(string authorName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .SingleOrDefault(e => e.Name == authorName);

                ctx.Authors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
