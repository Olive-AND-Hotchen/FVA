namespace DTO;

public record OrganisationRoleDto
{
    public int Id { get; set; }
    public OrganisationDto Organisation { get; set; }
    public int OrganisationId { get; set; }
    public PeopleContactDTO PeopleContact { get; set; }
    public int PeopleContactId { get; set; }
    public RoleDTO Role { get; set; }
    public int RoleId { get; set; }
}