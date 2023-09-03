using System;
using Api.Data.Models;
using Api.Data.Repositories.Abstract;
using Api.Data.Models.ViewModels;

namespace Api.Data.Repositories
{
    public class KimlikRepo : BaseRepository<KIMLIK, AppDbContext>
    {
        private readonly AppDbContext context;
        public KimlikRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

    }
}

