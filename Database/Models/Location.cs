using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database.Models;

[PrimaryKey("Id")]
[Table("Location")]
public class Location
{
    public int Id { get; set; }
    public string BuildingName { get; set; }
    public string BuildingNumber { get; set; }
    public string Street { get; set; }
    public string Area  { get; set; }
    public string Town { get; set; }
    public string Region { get; set; }
    public string Postcode { get; set; }
    public string ParkingDetails { get; set; }
    public string LocationType { get; set; }
    public PostcodeData PostcodeData { get; set; }
    public int PostcodeDataId { get; set; }
    public string LongtitudeLattitude { get; set; }
    public List<AccessibilityFeature> AccessibilityFeatures { get; set; }
}