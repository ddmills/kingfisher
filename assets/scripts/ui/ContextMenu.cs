using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour {

  private RectTransform rectTransform;
  private Canvas canvas;
  void Start () {
    rectTransform = GetComponent<RectTransform>();
    canvas = GetComponent<Canvas>();
  }

  public void Show() {
    canvas.enabled = true;
    Vector2 position = Input.mousePosition;
    position.y -= rectTransform.rect.height;
    Debug.Log(rectTransform.rect.height);
    Debug.Log(position);
    rectTransform.anchoredPosition = position;
  }

  public void Hide() {
    canvas.enabled = false;
  }
}
