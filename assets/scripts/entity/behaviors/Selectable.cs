using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerClickHandler {
  private bool selected = false;

  public bool Selected {
    get {
      return this.selected;
    }
  }

  public string label = "A thing";

  public void Select() {
    this.selected = true;
  }

  public void Deselect() {
    this.selected = false;
  }

  public void OnPointerClick(PointerEventData click) {
    Game.instance.cursor.Clicked(click);
  }
}
