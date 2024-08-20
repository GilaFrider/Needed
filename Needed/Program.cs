using System.IO;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Set the DataDirectory to the application's base directory
//string basePath = AppDomain.CurrentDomain.BaseDirectory;
//AppDomain.CurrentDomain.SetData("DataDirectory", basePath);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServices(builder.Configuration);

var MyAllowSpecificOrigins = "http://localhost:3000";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(MyAllowSpecificOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();
