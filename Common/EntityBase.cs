using System.ComponentModel.DataAnnotations;

namespace Common;

public abstract class EntityBase
{
    [Key]
    public Guid Key { get; set; }
}
