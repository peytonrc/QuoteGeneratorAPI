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
        private readonly Guid _userId;

        public AuthorService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var authorQuery =
                    ctx
                        .Authors
                        .Select(e => new AuthorListItem
                        {
                            AuthorId = e.AuthorId,
                            Name = e.Name,
                            BirthDate = e.BirthDate

                        });

                return authorQuery.ToArray();
            }
        }
        public bool CreateAuthor(AuthorCreate model)
        {
            var entity = new Author
            {
                Name = model.Name,
                BirthDate = model.BirthDate,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }



        public AuthorDetail GetAuthorById(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Authors.SingleOrDefault(e => e.AuthorId == authorId);

                return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        Name = entity.Name,
                        BirthDate = entity.BirthDate

                    };
            }
        }


        public bool UpdateAuthor(AuthorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .SingleOrDefault(e => e.AuthorId == model.AuthorId);

                entity.AuthorId = model.AuthorId;
                entity.Name = model.Name;
                entity.BirthDate = model.BirthDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .SingleOrDefault(e => e.AuthorId == authorId);

                ctx.Authors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
