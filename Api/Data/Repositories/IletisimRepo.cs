using System;
using Api.Data.Models.ViewModels;
using Api.Data.Models;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Repositories
{
    public class IletisimRepo : BaseRepository<ILETISIM, AppDbContext>
    {
        private readonly AppDbContext context;
        public IletisimRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

    }
}

