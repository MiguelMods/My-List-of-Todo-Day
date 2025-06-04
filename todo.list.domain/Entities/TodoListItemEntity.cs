using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class TodoListItemEntity : CommonEntity
{
    public long TodoListItemId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public IEnumerable<TodoItemEntity> TodoItemEntities { get; set; }
}
