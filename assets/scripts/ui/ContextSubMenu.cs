using UnityEngine;
using UnityEngine.UI;

public class ContextSubMenu : MonoBehaviour {

  public CanvasGroup canvasGroup;
  public RectTransform rectTransform;
  public Button button;

  void Start () {
    Hide();
    button.onClick.AddListener(delegate {
      Show();
    });
  }

  public void Show() {
    canvasGroup.alpha = 1;
    canvasGroup.blocksRaycasts = true;
    Vector2 position = new Vector2(140, -rectTransform.rect.height);
    rectTransform.anchoredPosition = position;
  }

  public void Hide() {
    canvasGroup.alpha = 0;
    canvasGroup.blocksRaycasts = false;
  }
}
