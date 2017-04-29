using UnityEngine;
using UnityEngine.EventSystems;

namespace King.UI.Cursor {
  public class CursorManager : MonoBehaviour {

    public GameObject cursor;
    public GameObject reticle;
    public GameObject blueprint;
    public ContextMenu contextMenu;
    private CursorAction action = new SelectingAction();

    void Update () {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, 100, 1 << 9)) {
        this.cursor.transform.position = hit.point;
      }
    }

    public void SetAction(CursorAction action) {
      this.action = action;
    }

    public string DescribeAction() {
      return this.action.name;
    }

    public void Clicked(PointerEventData data) {
      if (data.button.Equals(PointerEventData.InputButton.Left)) {
        action.OnLeftClick(data);
      } else if (data.button.Equals(PointerEventData.InputButton.Right)) {
        action.OnRightClick(data);
      } else if (data.button.Equals(PointerEventData.InputButton.Middle)) {
        action.OnMiddleClick(data);
      }
    }

    public void AbortAction() {
      this.action = new SelectingAction();
    }
  }
}
