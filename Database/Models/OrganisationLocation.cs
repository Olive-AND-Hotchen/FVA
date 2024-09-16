using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("OrganisationLocation")]
public class OrganisationLocation
{
    public int Id { get; set; }
    public Organisation Organisation { get; set; }
    public int OrganisationId { get; set; }
    public Location Location { get; set; }
    public int LocationId { get; set; }
}