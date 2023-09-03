using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;


namespace Api.Data.Models;

public class DERS_KAYIT : BaseEntity, IEntity
{
    //[ForeignKey("OGRENCI_ID")]
    public int OGR_ID { get; set; }
    //[ForeignKey("DERS_ID")]
    public int DERS_ID { get; set; }
    public DateTime CREATED_DATE { get; set; }

    // public List<OGRENCI> OGRENCILER { get; set; }
    // public List<DERS> DERSLER { get; set; }
}