using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class PermissionEntity : CommonEntity
{
    public long PermissionId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
