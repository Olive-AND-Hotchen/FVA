using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("Service")]
public class Service
{
    public int Id { get; set; }
    public Organisation Organisation { get; set; }
    public int OrganisationId { get; set; }
    public string ReferralDetails { get; set; }
    public string OperatingHours { get; set; }
    public string ServiceObjectives { get; set; }
    public string DemographicRestrictions { get; set; }
    public int ServiceCost  { get; set; }
    public string WorkerGenderChoice  { get; set; }
    public bool OutOfArea  { get; set; }
    public string AimsObjectives  { get; set; }
}