using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Server.Database.Models;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("OrganisationLocation")]
public class OrganisationLocation
{
    public int Id { get; set; }
    public required Organisation Organisation { get; set; }
    public int OrganisationId { get; set; }
    public required Location Location { get; set; }
    public int LocationId { get; set; }
}