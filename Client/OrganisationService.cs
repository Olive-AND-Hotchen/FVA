using DTO;

namespace Client;

public class OrganisationService(HttpClient client)
{
    public async Task<OrganisationDTO[]?> GetOrganisationsAsync()
    {
        return await client.GetFromJsonAsync<OrganisationDTO[]>("/api/organisations") ?? [];
    }
}