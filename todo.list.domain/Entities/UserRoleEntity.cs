using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class UserRoleEntity : CommonEntity
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public UserEntity? User { get; set; }
    public RoleEntity? Role { get; set; }
}
