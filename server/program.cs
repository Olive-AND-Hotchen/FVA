using FVA.Database;
using Microsoft.EntityFrameworkCore;
using Server.Static;

namespace Server;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDataProtection();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddAntiforgery();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<OdinDatabaseContext>(options => options.UseNpgsql(connectionString));
        var app = builder.Build();
        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapGet("/seed", async (context) => { await TestDataSeeding.Seed(context); });
        }

        app.UseAntiforgery();
        app.MapGet("/health", () => "App is healthy!");


        app.MapControllers();

        app.Run();
    }
}