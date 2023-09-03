namespace Api.Data.Models;
using Api.Data.Repositories.Abstract;


public class ILETISIM : BaseEntity, IEntity
{
    public string ADRES { get; set; }
    public string IL { get; set; }
    public string ILCE { get; set; }
    public string EMAIL { get; set; }
    public string GSM { get; set; }
}



