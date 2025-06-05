using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class UserTodoListItem : CommonEntity 
{
    public long UserTodoListItemId { get; set; }
    public long UserId { get; set; }
    public UserEntity User { get; set; }
    public long TodoListItemId { get; set; }
    public TodoListItemEntity TodoListItem { get; set; }
}