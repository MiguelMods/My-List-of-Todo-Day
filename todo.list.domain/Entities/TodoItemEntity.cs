using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class TodoItemEntity : CommonEntity
{
    public long TodoListItemId { get; set; }
    public long TodoItemId { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? StartAt { get; set; }
    public DateTime? EndAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
