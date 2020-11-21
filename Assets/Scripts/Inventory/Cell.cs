using UnityEngine;

public abstract class Cell : MonoBehaviour
{
    public abstract Item item { get; set; }
    public abstract void Additem(Item item);
}
