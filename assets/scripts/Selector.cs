using UnityEngine;
using King.Component;

namespace King {
  public class Selector : MonoBehaviour {
    public delegate void SelectHandler(GameObject selected);
    public delegate void DeselectHandler(GameObject deselected);
    public event SelectHandler OnSelect;
    public event DeselectHandler OnDeselect;
    public Selectable selected;

    void Start () {
      if (selected) {
        Select(selected);
      }
    }

    public bool TrySelect() {
      Deselect();
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, 100, 1 << 8)) {
        Selectable target = hit.transform.gameObject.GetComponent<Selectable>();
        if (target) {
          Select(target);
          return true;
        }
      }
      return false;
    }

    public void Select(Selectable target) {
      Deselect();
      target.Select();
      selected = target;

      Deletable deletable = target.GetComponent<Deletable>();
      if (deletable) {
        deletable.OnDelete += Deselect;
      }

      if (OnSelect != null) {
        OnSelect(selected.gameObject);
      }
    }

    public void Deselect() {
      if (selected) {
        GameObject deselected = selected.gameObject;
        selected.Deselect();
        Deletable deletable = selected.GetComponent<Deletable>();
        if (deletable) {
          deletable.OnDelete -= Deselect;
        }
        selected = null;
        if (OnDeselect != null) {
          OnDeselect(deselected);
        }
      }
    }
  }
}
