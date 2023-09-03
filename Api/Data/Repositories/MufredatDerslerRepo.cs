using System;
using Api.Data.Models.ViewModels;
using Api.Data.Models;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Repositories
{
    public class MufredatDerslerRepo : BaseRepository<MUFREDAT_DERSLER, AppDbContext>
    {
        private readonly AppDbContext context;
        public MufredatDerslerRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public void Custom()
        {

        }
    }
}

