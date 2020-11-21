
public class Potion : Item
{
    public override string Name { get; }
    public override string Type { get; }
    public override int Value { get; set; }
    public override int Price { get; set; }
    public override int MaxInCell { get; }
    public int HPRestore;
    public int MPRestore;
    public int XPBonus;
    public Potion(PotionSO potion)
    {
        Name = potion.Name;
        Type = potion.Type;
        Value = potion.Value;
        Price = potion.Price;
        MaxInCell = potion.MaxInCell;
        HPRestore = potion.HPRestore;
        MPRestore = potion.MPRestore;
        XPBonus = potion.XPBonus;
    }
}
