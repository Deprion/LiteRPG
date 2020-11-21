using System.Collections.Generic;
using UnityEngine;

public class DropHandler : MonoBehaviour
{
    public GameObject DropList, CellPrefab;
    public InventoryManager InvMan;
    public static DropHandler instance;
    private void Awake()
    {
        instance = this;
    }
    private void AddDrop(Item item)
    {
        var cell = Instantiate(CellPrefab);
        cell.GetComponent<CellDrop>().Additem(item);
        cell.transform.SetParent(DropList.transform, false);
        cell.GetComponent<CellDrop>().buttonPickUp.onClick.AddListener
            (delegate { cell.GetComponent<CellDrop>().DeleteCell(this); });
    }
    public bool AddItemToInventory(Item item)
    {
        if (InvMan.IsInvFull()) return false;
        else
        {
            InvMan.AddItem(item);
            return true;
        }
    }
    public void ShowDrop(List<Item> array)
    {
        DropList.SetActive(true);
        for (int i = 0; i < array.Count; i++)
        {
            AddDrop(array[i]);
        }
    }
}
