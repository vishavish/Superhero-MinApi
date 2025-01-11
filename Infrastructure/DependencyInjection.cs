using Infrastructure.Data;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Microsoft.Extensions.DependencyInjection;


public static class InfrastructureExtension
{
	public static void AddInfrastructure(this IHostApplicationBuilder builder)
	{
		var connectionString = builder.Configuration.GetConnectionString("SuperheroDb");

		builder.Services.AddDbContext<ApplicationDbContext>((opt) =>
		{
			opt.UseSqlite(connectionString);
		});

		builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
	}
}

