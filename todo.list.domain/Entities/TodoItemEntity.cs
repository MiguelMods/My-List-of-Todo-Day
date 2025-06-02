using todo.list.domain.Common;

namespace todo.list.domain.Entities;

public class TodoItemEntity : CommonEntity
{
    public long TodoItemId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
}
