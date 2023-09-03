using System;
using Api.Data.Models.ViewModels;
using Api.Data.Models;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Repositories
{
    public class DersKayitRepo : BaseRepository<DERS_KAYIT, AppDbContext>
    {
        private readonly AppDbContext context;
        public DersKayitRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

    }
}

