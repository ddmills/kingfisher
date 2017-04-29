using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextSubMenu : MonoBehaviour {

  public CanvasGroup canvasGroup;
  public Button button;
  void Start () {
    Debug.Log("start?");
    Hide();
    button.onClick.AddListener(delegate {
      Show();
    });
  }

  public void Show() {
    Debug.Log("SHOW");
    canvasGroup.alpha = 1;
    canvasGroup.blocksRaycasts = true;
    // Vector2 position = Input.mousePosition;
    // position.y -= rectTransform.rect.height;
    // Debug.Log(rectTransform.rect.height);
    // Debug.Log(position);
    // rectTransform.anchoredPosition = position;
  }

  public void Hide() {
    Debug.Log("HIDE");
    canvasGroup.alpha = 0;
    canvasGroup.blocksRaycasts = false;
  }
}
