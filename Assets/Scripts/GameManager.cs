using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DataScript dataScript;
    public DropHandler drop;
    public GameObject CellPrefab, InventoryMenu;
    public ItemSO[] ItemArray = new ItemSO[10];
    private void Awake()
    {
        dataScript = GetComponent<DataScript>();
        dataScript.LoadData();
        if (!dataScript.LoadData())
        {
            SceneManager.LoadScene(1);
        }
    }
    private void Start()
    {

    }
}
