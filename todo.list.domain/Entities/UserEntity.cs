using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class UserEntity : CommonEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Nickname { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public DateTime? LastLogin { get; set; }
    public IEnumerable<RoleEntity>? Roles { get; set; }
}
