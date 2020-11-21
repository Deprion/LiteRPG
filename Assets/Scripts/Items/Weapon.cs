using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private string _name;
    [SerializeField] private string _type;
    [SerializeField] private int _value;
    [SerializeField] private int _price;
    [SerializeField] private int _maxInCell;
    [SerializeField] private string _rarity;
    public override string Name { get; }
    public override string Type { get; }
    public override int Value { get; set; }
    public override int Price { get; set; }
    public override int MaxInCell { get; }
    public int DamageMax { get; set; }
    public int DamageMin { get; set; }
    public string Rarity { get; }

    public Weapon(string name, string type, int value, int price, int maxInCell, string rarity,
        int damageMax, int damageMin)
    {
        Name = name;
        Type = type;
        Value = value;
        Price = price;
        MaxInCell = maxInCell;
        Rarity = rarity;
        DamageMax = damageMax;
        DamageMin = damageMin;
    }
    public Weapon(WeaponSO item)
    {
        Name = item.Name;
        Type = item.Type;
        Value = item.Value;
        Price = item.Price;
        MaxInCell = item.MaxInCell;
        Rarity = item.Rarity;
        DamageMax = item.DamageMax;
        DamageMin = item.DamageMin;
    }
}
