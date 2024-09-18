using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("Service")]
public class Service
{
    public int Id { get; set; }
    public required Organisation Organisation { get; set; }
    public int OrganisationId { get; set; }
    public required string ReferralDetails { get; set; }
    public required string OperatingHours { get; set; }
    public required string ServiceObjectives { get; set; }
    public required string DemographicRestrictions { get; set; }
    public int ServiceCost  { get; set; }
    public required string WorkerGenderChoice  { get; set; }
    public bool OutOfArea  { get; set; }
    public required string AimsObjectives  { get; set; }
}