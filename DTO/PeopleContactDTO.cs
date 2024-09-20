namespace DTO;

public record PeopleContactDTO
{
    public int Id { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    public string DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}