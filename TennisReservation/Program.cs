using Microsoft.EntityFrameworkCore;
using TennisReservation.Data;
using TennisReservation.Services;
using FluentValidation;
using TennisReservation.Validation;
using FluentValidation.AspNetCore;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Register FluentValidation and scan the assembly for validators
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

// Enable FluentValidation for MVC
builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TennisReservationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserService,UserService>();

var app = builder.Build();

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
