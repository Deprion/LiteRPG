using UnityEngine.UI;

public class CellInventory : Cell
{
    public Button buttonPickUp;
    public Text Description, Name;
    public override Item item { get; set; }
    public int Count;

    public override void AddCell(Item _item) // добавление предмета и отображение информации о нем
    {
        item = _item;
        if (typeof(Weapon) == item.GetType())
        {
            var itemCurrent = (Weapon)item;
            Name.text = item.Name;
            Description.text = $"Min:{itemCurrent.DamageMin}  Max:{itemCurrent.DamageMax}";
        }
    }
    public void DeleteItem() // очистка информации
    {
        Name.text = null;
        Description.text = null;
    }

}
