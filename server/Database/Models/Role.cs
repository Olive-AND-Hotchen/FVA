using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("Role")]
public class Role
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public required string PublicContact { get; set; }
}