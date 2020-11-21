using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public string Name;
    public string Type;
    public int Value;
    public int Price;
    public int MaxInCell;
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")]
public class WeaponSO : ItemSO
{
    public int DamageMax;
    public int DamageMin;
    public string Rarity;
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Armor")]
public class ArmorSO : ItemSO
{

}

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Potion")]
public class PotionSO : ItemSO
{
    public int HPRestore;
    public int MPRestore;
    public int XPBonus;
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Stuff")]
public class StuffSO : ItemSO
{

}
