namespace Api.Data.Models;
using Api.Data.Repositories.Abstract;


public class MUFREDAT_DERSLER : BaseEntity, IEntity
{
    public int MUFREDAT_ID { get; set; }
    public int DERS_ID { get; set; }

    // public MUFREDAT MUFREDAT { get; set; }
    // public DERS DERS { get; set; }
}