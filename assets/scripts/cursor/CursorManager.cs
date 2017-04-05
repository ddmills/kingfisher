using UnityEngine;

public class CursorManager : MonoBehaviour {

  public GameObject cursor;
  public GameObject reticle;
  public GameObject blueprint;
  public CursorAction action = new SelectingAction();

  void Update () {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, 100, 1 << 9)) {
      this.cursor.transform.position = hit.point;
    }

    if (Input.GetMouseButtonDown(0)) {
      if (this.action != null) {
        action.Execute(this.reticle.transform);
      }
    }

    if (Input.GetMouseButtonDown(1)) {
      if (this.action != null) {
        action.Cancel(this.reticle.transform);
      }
    }
  }
}
