using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public Button SortNameButton, SortRarityButton, SortPriceButton;
    public GameObject CellPrefab, InventoryMenu;
    public CellInventory[] CellArray = new CellInventory[20];
    public static InventoryHandler instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        int x = 200;
        int y = 200;
        int count = 0;
        for (int i = 0; i < CellArray.Length / 5; i++)
        {
            for (int j = 0; j < CellArray.Length / 4; j++)
            {
                var obj = Instantiate(CellPrefab, new Vector2(x * (j + 1), y * (i + 1)),
                    Quaternion.identity);
                obj.transform.SetParent(InventoryMenu.transform, false);
                CellArray[count] = obj.GetComponent<CellInventory>();
                count++;
            }
        }
    }
}
