using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("AccessibilityFeature")]
public class AccessibilityFeature
{
    public int Id { get; set; }
    public required Location Location { get; set; }
    public int LocationId { get; set; }
    public required string Feature { get; set; }
}