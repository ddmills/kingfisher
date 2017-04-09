using UnityEngine;
using UnityEngine.UI;

public class SelectionDetails : MonoBehaviour {
  public Text label;

  void Start () {
    Hide();
    Game.instance.selector.OnSelect += OnObjectSelected;
    Game.instance.selector.OnDeselect += OnObjectDeselected;
  }

  public void OnObjectSelected(GameObject selected) {
    this.label.text = selected.GetComponent<Selectable>().label;
    Show();
  }

  public void OnObjectDeselected(GameObject deselected) {
    Hide();
  }

  private void Hide() {
    GetComponent<CanvasGroup>().alpha = 0;
    GetComponent<CanvasGroup>().blocksRaycasts = false;
  }

  private void Show() {
    GetComponent<CanvasGroup>().alpha = 1;
    GetComponent<CanvasGroup>().blocksRaycasts = true;
  }
}
