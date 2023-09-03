

using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Models;

public class OGRENCI : BaseEntity, IEntity
{
    public int OGR_NO { get; set; }
    //[ForeignKey("KIMLIK_ID")]
    public int KIMLIK_ID { get; set; }
    // [ForeignKey("MUFREDAT_ID")]
    public int MUFREDAT_ID { get; set; }

    //public KIMLIK KIMLIK { get; set; }
    // public MUFREDAT MUFREDAT { get; set; }
    // public List<DERS_KAYIT> DERS_KAYITs { get; set; }
}