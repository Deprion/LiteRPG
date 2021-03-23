using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Potion")]
public class PotionSO : ItemSO
{
    public int HPRestore;
    public int MPRestore;
    public int XPBonus;
}
