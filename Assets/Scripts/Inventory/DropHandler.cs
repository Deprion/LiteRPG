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
    private void AddDrop(Item item) // добавление Ячейки Дропа
    {
        var cell = Instantiate(CellPrefab); // создание префаба
        cell.GetComponent<CellDrop>().AddCell(item); // добавление предмета
        cell.transform.SetParent(DropList.transform, false); // установка родителя
        cell.GetComponent<CellDrop>().buttonPickUp.onClick.AddListener
            (delegate { cell.GetComponent<CellDrop>().DeleteCell(this); }); // добавление делегата подбора
    }
    public bool AddItemToInventory(Item item) // вызывается при подборе предмета
    {
        // добавление предмета в инвентарь
        if (InvMan.IsInvFull()) return false;
        else
        {
            InvMan.AddItem(item);
            return true;
        }
    }
    public void ShowDrop(List<Item> array) // вызывается при окончании боя
    {
        // отображение Панели Дропа и добавление дропа на Панель
        DropList.SetActive(true);
        for (int i = 0; i < array.Count; i++)
        {
            AddDrop(array[i]);
        }
    }
}
