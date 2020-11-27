using UnityEngine.UI;

public class CellDrop : Cell
{
    public Button buttonPickUp;
    public Text Description, Name;
    public override Item item { get; set; }

    public override void AddCell(Item _item) // добавление предмета и отображение информации о нем
    {
        item = _item;
        if (typeof(Weapon) == item.GetType())
        {
            var itemCurrent = (Weapon)item;
            Name.text = item.Name;
            Description.text = $"Min:{itemCurrent.DamageMin}  Max:{itemCurrent.DamageMax}";
        }
        Name.text = item.Name;
    }

    public void DeleteCell(DropHandler handler) // подбор предмета
    {
        if (handler.AddItemToInventory(item))
        {
            Destroy(gameObject);
        }
    }
}
