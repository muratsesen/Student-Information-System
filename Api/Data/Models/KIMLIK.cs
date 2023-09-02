using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Models;
public class KIMLIK : BaseEntity
{
    public long TC_NO { get; set; }
    public string AD { get; set; }
    public string SOYAD { get; set; }
    public string DOGUM_YERI { get; set; }
    public DateTime DOGUM_TARIHI { get; set; }
   // [ForeignKey("ILETISIM_ID")]
    public int ILETISIM_ID { get; set; }

    //public ILETISIM ILETISIM { get; set; }
}