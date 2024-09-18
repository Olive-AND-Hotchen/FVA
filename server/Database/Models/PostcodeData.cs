using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("PostcodeData")]
public class PostcodeData
{
    public int Id { get; set; }
    public required string OutwardCode { get; set; }
    public required string CouncilWard { get; set; }
    public required string CouncilConstituency { get; set; }
}