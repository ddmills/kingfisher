using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

  public Selectable selected;

  void Start () {
    if (this.selected) {
      this.Select(this.selected);
    }
  }

  void Update () {
    if (Input.GetMouseButtonDown(0)) {
      this.TrySelect();
    }
  }

  private void TrySelect() {
    this.Unselect();
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100, 1 << 8)) {
      Selectable target = hit.transform.gameObject.GetComponent<Selectable>();
      if (target) {
        this.Select(target);
      }
    }
  }

  public void Select(Selectable target) {
    this.Unselect();
    target.Select();
    this.selected = target;
  }

  public void Unselect() {
    if (this.selected) {
      this.selected.Unselect();
      this.selected = null;
    }
  }
}
