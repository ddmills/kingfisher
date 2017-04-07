using UnityEngine;

public class Selector : MonoBehaviour {
  public delegate void SelectHandler(GameObject selected);
  public delegate void DeselectHandler(GameObject deselected);
  public event SelectHandler OnSelect;
  public event DeselectHandler OnDeselect;
  public Selectable selected;

  void Start () {
    if (this.selected) {
      this.Select(this.selected);
    }
  }

  public bool TrySelect() {
    this.Deselect();
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100, 1 << 8)) {
      Selectable target = hit.transform.gameObject.GetComponent<Selectable>();
      if (target) {
        this.Select(target);
        return true;
      }
    }
    return false;
  }

  public void Select(Selectable target) {
    this.Deselect();
    target.Select();
    this.selected = target;
    if (this.OnSelect != null) {
      this.OnSelect(this.selected.gameObject);
    }
  }

  public void Deselect() {
    if (this.selected) {
      GameObject deselected = this.selected.gameObject;
      this.selected.Deselect();
      this.selected = null;
      if (this.OnDeselect != null) {
        this.OnDeselect(deselected);
      }
    }
  }
}
