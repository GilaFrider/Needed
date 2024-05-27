
using Bl;
using DataAccessLayer;
using DataBase.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<BlManager>();

builder.Services.AddControllers();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontend_url = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend_url)
        .AllowAnyMethod().AllowAnyHeader();
    });
});

//DBActions actions = new DBActions(builder.Configuration);
//var connString = actions.GetConnectionString("AcademyDB")
//builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(connString));

var app = builder.Build();
app.MapControllers();
app.UseCors();
app.MapGet("/", () => "Hello World!");
app.Run();