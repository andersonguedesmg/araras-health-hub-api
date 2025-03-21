using araras_health_hub_api.Models;

public class AccountWithRolesDto
{
  public int Id { get; set; }
  public string UserName { get; set; } = string.Empty;
  public string NormalizedUserName { get; set; } = string.Empty;
  public DateTime CreatedOn { get; set; }
  public DateTime UpdatedOn { get; set; }
  public bool IsActive { get; set; }
  public int DestinationId { get; set; }
  public Destination Destination { get; set; } = new Destination();
  public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
}
