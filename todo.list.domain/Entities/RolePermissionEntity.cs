using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class RolePermissionEntity : CommonEntity
{
    public long RolePermissionId { get; set; }
    public long RoleId { get; set; }
    public long PermissionId { get; set; }

    public RoleEntity Role { get; set; } = null!;
    public PermissionEntity Permission { get; set; } = null!;
}
