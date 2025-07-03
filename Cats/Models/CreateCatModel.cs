namespace Cats.Models;

public class CreateCatModel
{
    public string Name { get; set; }
    public string Color { get; set; }
}

public class CatCreated
{
    public Guid Guid { get; set; }
    public string Color { get; set; }
}