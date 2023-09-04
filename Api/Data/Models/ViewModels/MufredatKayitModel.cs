using System;
namespace Api.Data.Models.ViewModels
{
    public class MufredatKayitModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Lessons { get; set; }
    }
}

