using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CellInventory : Cell
{
    public Button buttonPickUp;
    public Text Description, Name;
    public override Item item { get; set; }
    public int Count;

    public override void Additem(Item _item)
    {
        item = _item;
        if (typeof(Weapon) == item.GetType())
        {
            var itemCurrent = (Weapon)item;
            Name.text = item.Name;
            Description.text = $"Min:{itemCurrent.DamageMin}  Max:{itemCurrent.DamageMax}";
        }
    }
    public void DeleteItem()
    {
        Name.text = null;
        Description.text = null;
    }

}
