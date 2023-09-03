namespace Api.Data.Models;
using Api.Data.Repositories.Abstract;

public class MUFREDAT : BaseEntity, IEntity
{
    public string MUFREDAT_ADI { get; set; }

    public ICollection<OGRENCI> OGRENCILER { get; set; }
    public ICollection<MUFREDAT_DERSLER> MUFREDAT_DERSLER { get; set; }
}


