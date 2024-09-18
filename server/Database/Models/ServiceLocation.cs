using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[Table("ServiceLocation")]
[PrimaryKey("Id")]
public class ServiceLocation
{
    public int Id { get; set; }
    public required Service Service { get; set; }
    public int ServiceId { get; set; }
    public int LocationId { get; set; }
    public required Location Location { get; set; }
}