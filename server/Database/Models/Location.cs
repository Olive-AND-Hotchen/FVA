using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("Location")]
public class Location
{
    public int Id { get; set; }
    public required string BuildingName { get; set; }
    public required string BuildingNumber { get; set; }
    public required string Street { get; set; }
    public required string Area  { get; set; }
    public required string Town { get; set; }
    public required string Region { get; set; }
    public required string Postcode { get; set; }
    public required string ParkingDetails { get; set; }
    public required string LocationType { get; set; }
    public required PostcodeData PostcodeData { get; set; }
    public int PostcodeDataId { get; set; }
    public required string LongtitudeLattitude { get; set; }
    public required List<AccessibilityFeature> AccessibilityFeatures { get; set; }
}