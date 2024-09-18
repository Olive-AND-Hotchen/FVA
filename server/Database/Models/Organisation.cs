using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[Table("Organisation")]
[PrimaryKey("Id")]
public class Organisation
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public bool OutOfArea  { get; set; }
    public required string Objectives  { get; set; }
    public required Organisation Parent { get; set; }
    public int ParentOrganisationId { get; set; }
    public required List<Service> Services { get; set; }
    public required List<OrganisationRole> OrganisationRoles { get; set; }
}