namespace DTO;

public record RoleDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string PublicContact { get; set; }
}