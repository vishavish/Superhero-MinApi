using System.Reflection;
using FluentValidation;


namespace Microsoft.Extensions.DependencyInjection;


public static class ApplicationExtension

{
	public static void AddApplication(this IHostApplicationBuilder builder)
	{
		builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		builder.Services.AddMediatR(cfg => {
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});
	}
}
