using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[Table("OrganisationRole")]
[PrimaryKey("Id")]
public class OrganisationRole
{
    public int Id { get; set; }
    public Organisation Organisation { get; set; }
    public int OrganisationId { get; set; }
    public PeopleContact PeopleContact { get; set; }
    public int PeopleContactId { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
}