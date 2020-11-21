
public abstract class Item
{
    public abstract string Name { get; }
    public abstract string Type { get; }
    public abstract int Value { get; set; }
    public abstract int Price { get; set; }
    public abstract int MaxInCell { get; }
}
