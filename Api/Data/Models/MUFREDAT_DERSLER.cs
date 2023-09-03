namespace Api.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;


public class MUFREDAT_DERSLER : BaseEntity, IEntity
{
    [ForeignKey("MUFREDAT_ID")]
    public int MUFREDAT_ID { get; set; }
    public MUFREDAT MUFREDAT { get; set; }

    [ForeignKey("DERS_ID")]
    public int DERS_ID { get; set; }
    public DERS DERS { get; set; }

}