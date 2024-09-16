using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("PostcodeData")]
public class PostcodeData
{
    public int Id { get; set; }
    public string OutwardCode { get; set; }
    public string CouncilWard { get; set; }
    public string CouncilConstituency { get; set; }
}