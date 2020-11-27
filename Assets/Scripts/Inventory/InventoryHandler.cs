using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public Button SortNameButton, SortRarityButton, SortPriceButton;
    public GameObject CellPrefab, InventoryMenu;
    private void Awake()
    {
        int x = 200;
        int y = 200;
        int count = 0;
        for (int i = 0; i < InventoryManager.instance.CellArray.Length / 5; i++)
        {
            for (int j = 0; j < InventoryManager.instance.CellArray.Length / 4; j++)
            {
                var obj = Instantiate(CellPrefab, new Vector2(x * (j + 1), y * (i + 1)),
                    Quaternion.identity);
                obj.transform.SetParent(InventoryMenu.transform, false);
                InventoryManager.instance.CellArray[count] = obj.GetComponent<CellInventory>();
                count++;
            }
        }
    }
}
