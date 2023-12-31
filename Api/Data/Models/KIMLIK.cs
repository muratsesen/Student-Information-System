using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;


namespace Api.Data.Models;
public class KIMLIK : BaseEntity, IEntity
{
    public long TC_NO { get; set; }
    public string AD { get; set; }
    public string SOYAD { get; set; }
    public string DOGUM_YERI { get; set; }
    public DateTime DOGUM_TARIHI { get; set; }
    [ForeignKey("ILETISIMID")]
    public int ILETISIMID { get; set; }

    public ILETISIM ILETISIM { get; set; }
}