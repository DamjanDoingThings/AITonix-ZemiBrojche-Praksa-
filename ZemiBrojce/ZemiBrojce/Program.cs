using Microsoft.EntityFrameworkCore;
using ZemiBrojce.Models;
using ZemiBrojce.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISalterService,SalterService>();
builder.Services.AddScoped<IUslugaService, UslugaService>();
builder.Services.AddScoped<INumberService, NumberService>();
builder.Services.AddDbContext<Praksa_ZemiBrojContext>(
        options => options.UseSqlServer(builder.Configuration["ConnectionString"]));
//ENABLE CORS
builder.Services.AddCors(options =>
{
options.AddPolicy("CorsPolicy",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("CorsPolicy");

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
