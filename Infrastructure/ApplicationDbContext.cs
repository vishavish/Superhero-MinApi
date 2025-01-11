using System.Reflection;
using Application.Common.Interfaces;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

	public DbSet<Hero>? Heroes { get; set; }
    public DbSet<Organization>? Organizations { get; set; }


	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
