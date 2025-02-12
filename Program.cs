using Controllers;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.AddApplication();
builder.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();	
	app.MapScalarApiReference();
} 

WeatherEndpoints.Map(app);
HeroEndpoints.Map(app);
OrganizationEndpoints.Map(app);

app.Run();
