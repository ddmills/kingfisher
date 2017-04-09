using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerClickHandler {
  private bool _selected = false;
  public bool isEnabled = true;

  public bool selected {
    get { return _selected; }
  }

  public string label = "Entity";

  public void Select() {
    _selected = true;
  }

  public void Deselect() {
    _selected = false;
  }

  public void OnPointerClick(PointerEventData click) {
    Game.instance.cursor.Clicked(click);
  }
}
