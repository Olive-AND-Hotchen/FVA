using DTO;

namespace Client;

public class OrganisationService(HttpClient client)
{
    public async Task<OrganisationDto[]?> GetOrganisationsAsync()
    {
        return await client.GetFromJsonAsync<OrganisationDto[]>("/api/organisations") ?? [];
    }
}