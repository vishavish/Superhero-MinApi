var builder = WebApplication.CreateBuilder(args);

builder.AddApplication();
builder.AddInfrastructure();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
