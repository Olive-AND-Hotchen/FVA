using Microsoft.EntityFrameworkCore;

namespace FVA.Database;

public class OdinDatabaseContext(
    DbContextOptions
        <OdinDatabaseContext> options) : DbContext(options)
{
    
}