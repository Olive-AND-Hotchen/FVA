using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("AccessibilityFeature")]
public class AccessibilityFeature
{
    public int Id { get; set; }
    public Location Location { get; set; }
    public int LocationId { get; set; }
    public string Feature { get; set; }
}