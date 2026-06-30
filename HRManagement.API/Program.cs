using HRManagement.API;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();

var app = builder.Build();
app.ConfigurePipelines();

await app.SeedRolesAsync();
app.Run();
