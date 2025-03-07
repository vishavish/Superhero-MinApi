namespace Domain.Common;

public abstract class AuditableEntity
{
	public string? CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? ModifiedBy { get; set; }
	public DateTime ModifiedOn { get; set; }
}
