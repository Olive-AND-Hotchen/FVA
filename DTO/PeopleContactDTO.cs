namespace DTO;

public record PeopleContactDTO
{
    public int Id { get; set; }
    public required string Forename { get; set; }
    public required string Surname { get; set; }
    public required string DateOfBirth { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
}