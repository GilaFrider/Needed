
using DataAccessLayer;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DBActions actions = new DBActions(builder.Configuration);
var connString = actions.GetConnectionString("AcademyDB");
builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(connString));
//builder.Services.AddScoped<IUniversityRepo, UniversityRepo>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();