namespace Api.Data.Models;
public class DERS : BaseEntity
{
    public string DERS_KODU { get; set; }
    public string DERS_ADI { get; set; }
    public int DURUM { get; set; }
    public int KREDI { get; set; }
}


