namespace Api.Data.Models;
using Api.Data.Repositories.Abstract;


public class DERS : BaseEntity, IEntity
{
    public string DERS_KODU { get; set; }
    public string DERS_ADI { get; set; }
    public int DURUM { get; set; }
    public int KREDI { get; set; }

    public ICollection<MUFREDAT_DERSLER> MUFREDAT_DERSLERs { get; set; }
    public ICollection<DERS_KAYIT> DERS_KAYITLARI { get; set; }

}


