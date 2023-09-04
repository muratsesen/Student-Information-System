

using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;

namespace Api.Data.Models;

public class OGRENCI : BaseEntity, IEntity
{
    public int OGR_NO { get; set; }
    //[ForeignKey("KIMLIKID")]
    public int KIMLIKID { get; set; }
    // [ForeignKey("MUFREDATID")]
    public int MUFREDATID { get; set; }

    public KIMLIK KIMLIK { get; set; }
    public MUFREDAT MUFREDAT { get; set; }
    public ICollection<DERS_KAYIT> DERS_KAYITLARI { get; set; }
}