using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public string Class { get; set; }
    public string Race { get; set; }
    public string Faith { get; set; }
    public string Zodiac { get; set; }
    public int[] BaseStats = new int[6] { 0, 0, 0, 0, 0, 0 };
    public int HP { get; set; }
    public int Level;
    public int XP;
    public int CurrentDamage = 1;
    public Weapon CurrentWeapon;
}
