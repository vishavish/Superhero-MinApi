using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Configuration;


public class HeroConfiguration : IEntityTypeConfiguration<Hero>
{
	public void Configure(EntityTypeBuilder<Hero> builder)
	{
		builder.Property(h => h.Name)
			.HasMaxLength(20)
			.IsRequired();	

		builder.Property(h => h.Ability)
			.HasMaxLength(20)
			.IsRequired();

		builder.Property(h => h.PowerLevel)
			.IsRequired();
	}
}
