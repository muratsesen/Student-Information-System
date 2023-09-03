using System;
using Api.Data.Models.ViewModels;
using Api.Data.Models;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Repositories
{
    public class DersRepo : BaseRepository<DERS, AppDbContext>
    {
        private readonly AppDbContext context;
        public DersRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

    }
}

