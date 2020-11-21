using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInventory : Cell
{
    public override Item item { get; set; }
    public int Count;

    public override void Additem(Item item)
    {
        throw new System.NotImplementedException();
    }

}
