using UnityEngine.UI;

public class CellDrop : Cell
{
    public Button buttonPickUp;
    public Text Description, Name;
    public override Item item { get; set; }

    public override void Additem(Item _item)
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

    public void DeleteCell(DropHandler handler)
    {
        if (handler.AddItemToInventory(item))
        {
            Destroy(gameObject);
        }
    }
}
