using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SmartParkingApi.Data;
using SmartParkingApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("SmartParkingDb"));

builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Smart Parking API", Version = "v1" });

});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Parking API V1");
});


app.MapControllers();
app.Run();
