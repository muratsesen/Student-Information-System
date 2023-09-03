using System;
using Api.Data.Models.ViewModels;
using Api.Data.Models;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Repositories
{
    public class MufredatRepo : BaseRepository<MUFREDAT, AppDbContext>
    {
        private readonly AppDbContext context;
        public MufredatRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

    }
}

