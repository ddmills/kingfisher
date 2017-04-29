using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour {

  private RectTransform rectTransform;
  private CanvasGroup canvasGroup;
  void Start () {
    rectTransform = GetComponent<RectTransform>();
    canvasGroup = GetComponent<CanvasGroup>();
    Hide();
  }

  public void Show() {
    canvasGroup.alpha = 1;
    canvasGroup.blocksRaycasts = true;
    Vector2 position = Input.mousePosition;
    position.y -= rectTransform.rect.height;
    rectTransform.anchoredPosition = position;
  }

  public void Hide() {
    canvasGroup.alpha = 0;
    canvasGroup.blocksRaycasts = false;
  }
}
