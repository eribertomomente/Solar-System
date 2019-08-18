using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class HighlightUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color highlightedColor;
    public Color notHighlightedColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = notHighlightedColor;
    }
}
