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
        Dictionary<int, List<int>> valueList = new Dictionary<int, List<int>>() { { 1, new List<int> { 0, 50 } }, { 2, new List<int> { 10 } }, { 3, new List<int> { 100 } }, { 4, new List<int> { 50 } } };
        ShowGraph(valueList);
    }

    void CreateCircle(Vector2 anchoredPosition)
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

    void ShowGraph(Dictionary<int, List<int>> valueList)
    {
        float xSize = ((graphContainer.sizeDelta.x - 20) / valueList.Count);
        float yMax = 100;
        float graphHeight = graphContainer.sizeDelta.y;
        int counter = 0;
        foreach (KeyValuePair<int, List<int>> entry in valueList)
        {
            float xPos = 20 + counter * xSize;
            foreach (int data in entry.Value)
            {
                float yPos = (data / yMax) * graphHeight;
                CreateCircle(new Vector2(xPos, yPos));
            }
            GameObject gameObject = new GameObject("index");
            gameObject.transform.SetParent(this.graphContainer.transform);
            Text index = gameObject.AddComponent<Text>();
            index.text = entry.Key.ToString();
            index.transform.position = new Vector3(xPos, 5, 0);
            counter++;
        }
    }
}
