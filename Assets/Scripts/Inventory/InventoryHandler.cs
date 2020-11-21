using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public Button SortNameButton, SortRarityButton, SortPriceButton;
    public GameObject CellPrefab;
    public CellInventory[] CellArray = new CellInventory[20];
    public static InventoryHandler instance;
    private void Awake()
    {
        instance = this;
    }
}
