using Common;

namespace Dogs.Models;

public class Dog : EntityBase
{
    public string Name { get; set; } = default!;
    public bool CanDoTricks { get; set; }
}
