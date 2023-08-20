using Common;

namespace Cats.Models;

public class Cat : EntityBase
{
    public string Name { get; set; } = default!;
    public string Color { get; set; } = default!;
}
