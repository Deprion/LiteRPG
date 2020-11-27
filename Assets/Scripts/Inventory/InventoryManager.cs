using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Item[] Inventory = new Item[20];
    public delegate void UpdateInventory(int index, Item _item, bool IsAdd);
    public event UpdateInventory UpdateEvent;
    private void Awake()
    {
        UpdateEvent += UpdateCell;
    }
    public void AddItem(Item item)
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] == null)
            {
                Inventory[i] = item;
                UpdateEvent?.Invoke(i, item, true);
                break;
            }
            else if (Inventory[i].GetType().Equals(item.GetType()))
            {
                if (Inventory[i].MaxInCell > 1 &&
                    InventoryHandler.instance.CellArray[i].Count != Inventory[i].MaxInCell)
                {
                    InventoryHandler.instance.CellArray[i].Count += 1;
                    UpdateEvent?.Invoke(i, item, true);
                    break;
                }
            }
        }
        DebugInfo();
    }
    public void DeleteItem(int index)
    {
        if (InventoryHandler.instance.CellArray[index].Count == 1)
        {
            Inventory[index] = null;
        }
        else
        {
            InventoryHandler.instance.CellArray[index].Count -= 1;
        }
        UpdateEvent?.Invoke(index, Inventory[index], false);
    }
    public void Resort()
    { 
        
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
                else if (Inventory[i].GetType().Equals(typeof(Armor)))
                {
                    var item = (Armor)Inventory[i];
                    Debug.Log(item.Name);
                }
                else if (Inventory[i].GetType().Equals(typeof(Stuff)))
                {
                    var item = (Stuff)Inventory[i];
                    Debug.Log(item.Name);
                }
            }
        }
    }
    public bool IsInvFull()
    {
        if (Inventory[Inventory.Length - 1] != null) return true;
        else return false;
    }
    private void UpdateCell(int index, Item _item, bool IsAdd)
    {
        if (IsAdd) InventoryHandler.instance.CellArray[index].Additem(_item);
        else InventoryHandler.instance.CellArray[index].DeleteItem();
    }
}
