using System;
using Api.Data.Models.ViewModels;
using Api.Data.Models;

namespace Api.Data.Repositories
{
    public class OgrenciRepo
    {
        private readonly AppDbContext context;
        public OgrenciRepo(AppDbContext dbContext)
        {
            context = dbContext;
        }

        public OGRENCI Ekle(OGRENCI model)
        {
            context.OGRENCILER.Add(model);
            context.SaveChanges();
            return model;
        }
    }
}

