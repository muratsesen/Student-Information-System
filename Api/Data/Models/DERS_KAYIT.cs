using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;


namespace Api.Data.Models;

public class DERS_KAYIT : BaseEntity, IEntity
{
    [ForeignKey("OGRID")]
    public int OGRENCIID { get; set; }
    [ForeignKey("DERSID")]
    public int DERSID { get; set; }
    public DateTime CREATED_DATE { get; set; }

    public OGRENCI OGRENCI { get; set; }
    public DERS DERS { get; set; }
}