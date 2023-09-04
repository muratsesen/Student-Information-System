namespace Api.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;


public class MUFREDAT_DERSLER : BaseEntity, IEntity
{
    [ForeignKey("MUFREDATID")]
    public int MUFREDATID { get; set; }
    public MUFREDAT MUFREDAT { get; set; }

    [ForeignKey("DERSID")]
    public int DERSID { get; set; }
    public DERS DERS { get; set; }

}