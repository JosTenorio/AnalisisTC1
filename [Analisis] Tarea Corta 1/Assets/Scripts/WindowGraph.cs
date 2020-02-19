using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    void Awake()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
        List<int> valueList = new List<int>() { 0, 10, 50, 100, 50};
        showGraph(valueList);
    }

    void createCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    void showGraph(List<int> valueList)
    {
        float xSize = 50f;
        float yMax = 100f + 5;
        float graphHeight = graphContainer.sizeDelta.y;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPos = 20 + i * xSize;
            float yPos = 10 + (valueList[i] / yMax) * graphHeight;
            createCircle(new Vector2(xPos, yPos));
        }
    }
}
