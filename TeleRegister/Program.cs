using Microsoft.EntityFrameworkCore;
using TeleRegister.Controllers;
using TeleRegister.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<DBContext>();
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddScoped<DoctorController>();
builder.Services.AddScoped<PatientController>();
builder.Services.AddScoped<RegisterController>();
builder.Services.AddScoped<LoginController>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
 {
     c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
       .AllowAnyHeader());
 });

var app = builder.Build();

//DBContext

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
