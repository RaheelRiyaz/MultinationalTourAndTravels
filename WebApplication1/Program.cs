using MultinationalTourAndTravels.Api.DIContainer;
using MultinationalTourAndTravels.Application.DIContainer;
using MultinationalTourAndTravels.Infrastructure.DIContainer;
using MultinationalTourAndTravels.Persistence.DIContainer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration).
    AddApiServices(builder.Configuration).
    AddInfrastructureServices().
    AddApplicationServices(builder.Environment.WebRootPath);
var app = builder.Build();
app.UseStaticFiles();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
