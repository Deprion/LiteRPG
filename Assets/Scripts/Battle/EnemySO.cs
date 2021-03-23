using UnityEngine;

[CreateAssetMenu(fileName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public string Name;
    public int HP;
    public int DamageMin;
    public int DamageMax;
    public int XP;
    public ItemSO[] ItemArray = new ItemSO[] { };
    public float[] ItemChances = new float[] { };
    [System.Serializable]
    public class info
    {
        [SerializeField]
        ItemSO item;
        [SerializeField]
        float chance;
    }
    public info[] info1;
}
