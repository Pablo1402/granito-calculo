using Ampulheta.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AmpulhetaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AmpulhetaContext>();
    dataContext.Database.Migrate();
    dataContext.Execute();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
