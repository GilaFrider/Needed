
using Bl;
using DataAccessLayer;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<BlManager>();

builder.Services.AddControllers();
//DBActions actions = new DBActions(builder.Configuration);
//var connString = actions.GetConnectionString("AcademyDB");

//builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(connString));
//builder.Services.AddScoped<IUniversityRepo, UniversityRepo>();

var app = builder.Build();
app.MapControllers();


app.MapGet("/", () => "Hello World!");

app.Run();