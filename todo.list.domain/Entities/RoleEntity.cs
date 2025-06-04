using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class RoleEntity : CommonEntity
{
    public long RoleId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<RolePermissionEntity> RolePermissions { get; set; }
}
