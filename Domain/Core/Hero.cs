using Domain.Common;


namespace Domain.Core;

public class Hero : AuditableEntity
{
	public Guid Id { get; init; }
	public string? Name { get; set; }
	public string? Ability { get; set; }
	public int PowerLevel { get; set; }
	public Organization? Organization { get; set; }
	public Guid? OrganizationId { get; set; }

	public Hero() {}

	public void Update (
		string name,
		string ability,
		int powerLevel)
	{
		Name = name;
		Ability = ability;
		PowerLevel = powerLevel;
	}

	public override string ToString()
	{
		return $"{ Name } has { Ability  } abiilities. Power Level is : { PowerLevel }";
	}
	
}
