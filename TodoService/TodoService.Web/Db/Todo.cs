using System.Text.Json.Serialization;

namespace TodoService.Web.Db;

public class Todo : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public abstract class BaseEntity
{
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}