using UnityEngine;

public class Selectable : MonoBehaviour {

  private bool selected = false;

  public bool Selected {
    get {
      return this.selected;
    }
  }

  public void Select() {
    this.selected = true;
  }

  public void Deselect() {
    this.selected = false;
  }
}
