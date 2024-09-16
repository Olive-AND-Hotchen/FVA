using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[Table("Organisation")]
[PrimaryKey("Id")]
public class Organisation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public bool OutOfArea  { get; set; }
    public string Objectives  { get; set; }
    public Organisation Parent { get; set; }
    public int ParentOrganisationId { get; set; }
    public List<Service> Services { get; set; }
    public List<OrganisationRole> OrganisationRoles { get; set; }
}