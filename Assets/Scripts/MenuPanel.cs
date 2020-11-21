using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    private float moveSpeed = 3000;
    private RectTransform transformPanel;
    private Vector2 target;
    private void Start()
    {
        transformPanel = GetComponent<RectTransform>();
        target = transformPanel.anchoredPosition;
    }
    void Update()
    {
        RevealMenu();
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target = new Vector2(transformPanel.sizeDelta.x / 2,
                    transformPanel.anchoredPosition.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target = new Vector2(-transformPanel.sizeDelta.x / 2,
                    transformPanel.anchoredPosition.y);
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.deltaPosition.x > 75)
                target = new Vector2(transformPanel.sizeDelta.x / 2,
                    transformPanel.anchoredPosition.y);
            if (touch.deltaPosition.x < -75)
                target = new Vector2(-transformPanel.sizeDelta.x / 2,
                    transformPanel.anchoredPosition.y);
        }
    }
    public void RevealMenu()
    {
        transformPanel.anchoredPosition = Vector2.MoveTowards(transformPanel.anchoredPosition,
                    target, moveSpeed * Time.deltaTime);
    }
    public void HideMenu()
    {
        target = new Vector2(-transformPanel.sizeDelta.x / 2, transformPanel.anchoredPosition.y);
        transformPanel.anchoredPosition = Vector2.MoveTowards(transformPanel.anchoredPosition,
                    target, moveSpeed * Time.deltaTime);
    }
}
