using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("PeopleContact")]
public class PeopleContact
{
    public int Id { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    public string DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}