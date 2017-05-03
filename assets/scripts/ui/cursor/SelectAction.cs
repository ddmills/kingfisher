using UnityEngine.EventSystems;
using King.Component;

namespace King.UI.Cursor {
  class SelectAction : CursorAction {
    public override string name {
      get {
        return "select";
      }
    }

    public override void OnLeftClick(PointerEventData data) {
      Game.instance.cursor.contextMenu.Hide();
      Selectable selectable = data.pointerPress.GetComponent<Selectable>();
      if (selectable && selectable.isEnabled) {
        Game.instance.selector.Select(selectable);
      } else {
        Game.instance.selector.Deselect();
      }
    }

    public override void OnRightClick(PointerEventData data) {
      Game.instance.cursor.contextMenu.Show();
    }

    public override void OnAbort() {
      Game.instance.selector.Deselect();
    }
  }
}
