using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Item[] Inventory = new Item[20];
    public void AddItem(Item item)
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] == null)
            {
                Inventory[i] = item;
                break;
            }
            else if (Inventory[i].GetType().Equals(item.GetType()))
            {
                if (Inventory[i].MaxInCell > 1 && 
                    InventoryHandler.instance.CellArray[i].Count != Inventory[i].MaxInCell)
                {
                    InventoryHandler.instance.CellArray[i].Count += 1;
                }
            }
        }
        DebugInfo();
    }
    public void DebugInfo()
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] != null)
            {
                if (Inventory[i].GetType().Equals(typeof(Weapon)))
                {
                    var item = (Weapon)Inventory[i];
                    Debug.Log(item.Rarity);
                }
                else if (Inventory[i].GetType().Equals(typeof(Potion)))
                {
                    var item = (Potion)Inventory[i];
                    Debug.Log(item.HPRestore);
                }
            }
        }
    }
    public bool IsInvFull()
    {
        if (Inventory[Inventory.Length - 1] != null) return true;
        else return false;
    }
}
