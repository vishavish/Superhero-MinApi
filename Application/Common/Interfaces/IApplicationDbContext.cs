using Domain.Core;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces;


public interface IApplicationDbContext
{
	DbSet<Hero>? Heroes { get; set; }
	DbSet<Organization>? Organizations { get; set; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
