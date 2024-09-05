using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[Table("Test")]
[PrimaryKey("TestId")]
public class TestModel
{
    public int TestId { get; set; }
    public string TestName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public bool Deleted { get; set; }
}