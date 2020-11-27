using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public CellInventory[] CellArray = new CellInventory[20];
    public delegate void UpdateInventory(int index, Item _item, bool IsAdd);
    public event UpdateInventory UpdateEvent;
    public static InventoryManager instance;
    // ивент и делегат был добавлен лишь для практики. Фактического применения нет
    private void Awake()
    {
        if (instance == null) instance = this;
        UpdateEvent += UpdateCell; // назначаем ивент
    }
    public void AddItem(Item item)
    {
        for (int i = 0; i < CellArray.Length; i++)
        {
            if (CellArray[i].item == null) // проверяем ячейку на свободность
            {
                CellArray[i].item = item;
                UpdateEvent?.Invoke(i, item, true); // событие обновления ячейки
                break;
            }
            else if (CellArray[i].item.GetType().Equals(item.GetType())) // проверка на одинаковый тип
            {
                if (CellArray[i].item.MaxInCell > CellArray[i].Count)
                { // проверка на вместимость
                    CellArray[i].Count += 1;
                    UpdateEvent?.Invoke(i, item, true);
                    break;
                }
            }
        }
        DebugInfo();
    }
    public void DeleteItem(int index)
    {
        if (CellArray[index].Count == 1)
        {
            CellArray[index].item = null;
        }
        else
        {
            CellArray[index].Count -= 1;
        }
        UpdateEvent?.Invoke(index, CellArray[index].item, false);
    }
    public void Resort()
    {
        // сортировка инвентаря по текущим настройкам при удалении/добавлении предмета
    }
    public void DebugInfo()
    {
        // в будущем будет удалено
        for (int i = 0; i < CellArray.Length; i++)
        {
            if (CellArray[i] != null)
            {
                if (CellArray[i].GetType().Equals(typeof(Weapon)))
                {
                    var item = (Weapon)CellArray[i].item;
                    Debug.Log(item.Rarity);
                }
                else if (CellArray[i].GetType().Equals(typeof(Potion)))
                {
                    var item = (Potion)CellArray[i].item;
                    Debug.Log(item.HPRestore);
                }
                else if (CellArray[i].GetType().Equals(typeof(Armor)))
                {
                    var item = (Armor)CellArray[i].item;
                    Debug.Log(item.Name);
                }
                else if (CellArray[i].GetType().Equals(typeof(Stuff)))
                {
                    var item = (Stuff)CellArray[i].item;
                    Debug.Log(item.Name);
                }
            }
        }
    }
    public bool IsInvFull()
    {
        // проверка на заполненость инвентаря
        if (CellArray[CellArray.Length - 1].item != null) return true;
        else return false;
    }
    private void UpdateCell(int index, Item _item, bool IsAdd)
    {
        // обновление ячейки - добавление предмета или удаление
        if (IsAdd) CellArray[index].AddCell(_item);
        else CellArray[index].DeleteItem();
    }
}
