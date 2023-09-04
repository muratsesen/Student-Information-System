using System;
using Api.Data.Models.ViewModels;
using Api.Data.Models;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Repositories
{
    public class OgrenciRepo : BaseRepository<OGRENCI, AppDbContext>
    {
        private readonly AppDbContext context;
        public OgrenciRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }


    }
}

