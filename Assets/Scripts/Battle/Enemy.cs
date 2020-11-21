using System;
using UnityEngine;

public class Enemy
{
    public string Name;
    public int HP;
    public int DamageMin;
    public int DamageMax;
    public int XP;
    public Item[] ItemArray = new Item[] { };
    public float[] ItemChances = new float[] { };
    public Enemy(EnemySO enemy)
    {
        Name = enemy.Name;
        HP = enemy.HP;
        DamageMin = enemy.DamageMin;
        DamageMax = enemy.DamageMax;
        XP = enemy.XP;
        ItemArray = Array.ConvertAll(enemy.ItemArray, new Converter<ItemSO, Item>(ItemSoToItem));
        ItemChances = enemy.ItemChances;
    }
    public Enemy Assignment(EnemySO enemySO)
    {
        return new Enemy(enemySO);
    }
    public static Item ItemSoToItem(ItemSO itemSO)
    {
        if (itemSO.Equals(null)) return null;
        else if (itemSO.GetType().Equals(typeof(WeaponSO)))
        {
            return new Weapon((WeaponSO)itemSO);
        }
        else //if (itemSO.GetType().Equals(typeof(PotionSO)))
        {
            return new Potion((PotionSO)itemSO);
        }
    }
}
