using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

  private bool selected = false;

  public bool Selected {
    get {
      return this.selected;
    }
  }

  public void Select() {
    Debug.Log("SELECTED");
    this.selected = true;
  }

  public void Unselect() {
    Debug.Log("UNSELECTED");
    this.selected = false;
  }
}
