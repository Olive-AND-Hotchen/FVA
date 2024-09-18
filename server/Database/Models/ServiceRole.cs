using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("ServiceRole")]
public class ServiceRole
{
    public int Id { get; set; }
    public required Role Role { get; set; }
    public int RoleId { get; set; }
    public required PeopleContact PeopleContact { get; set; }
    public int PeopleContactId { get; set; }
}