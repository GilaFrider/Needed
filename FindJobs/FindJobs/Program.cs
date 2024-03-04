




var builder = WebApplication.CreateBuilder(args);
DBActions actions = new DBActions(builder.Configuration);
var connString = actions.GetConnectionString("FactoryFoodDB");
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connString));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();