using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("PeopleContact")]
public class PeopleContact
{
    public int Id { get; set; }
    public required string Forename { get; set; }
    public required string Surname { get; set; }
    public required string DateOfBirth { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
}