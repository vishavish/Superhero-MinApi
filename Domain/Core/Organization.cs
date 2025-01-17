using Domain.Common;

namespace Domain.Core;

public class Organization : AuditableEntity
{
	public Guid Id { get; init; }
	public string? Name { get; set; }
	public List<Hero> Heroes = new();

	public void Update(string name)
	{
		Name = name;
	}
}

