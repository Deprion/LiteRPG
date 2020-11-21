using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public override string Name { get; }
    public override string Type { get; }
    public override int Value { get; set; }
    public override int Price { get; set; }
    public override int MaxInCell { get; }
}
