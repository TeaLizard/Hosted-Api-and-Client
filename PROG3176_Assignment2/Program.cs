using Microsoft.EntityFrameworkCore;
using PROG3176_Assignment2.Data;
using PROG3176_Assignment2.Repositories;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=TestDb.db",
            x => x.MigrationsAssembly("PROG3176_Assignment2.Migrations.Sqlite")));
}
else
{
    var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString,
            x => x.MigrationsAssembly("PROG3176_Assignment2.Migrations.Postgres")));
}



builder.Services.AddScoped<AnimalRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsProduction())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();