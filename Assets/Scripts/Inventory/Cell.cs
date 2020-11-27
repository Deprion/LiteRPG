using UnityEngine;

public abstract class Cell : MonoBehaviour
{
    public abstract Item item { get; set; }
    public abstract void AddCell(Item item);
}
