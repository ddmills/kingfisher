using UnityEngine.EventSystems;
using King.Component;

namespace King.UI.Cursor {
  class SelectingAction : CursorAction {
    public override string name {
      get {
        return "select";
      }
    }

    public override void OnLeftClick(PointerEventData data) {
      Selectable selectable = data.pointerPress.GetComponent<Selectable>();
      if (selectable && selectable.isEnabled) {
        Game.instance.selector.Select(selectable);
      } else {
        Game.instance.selector.Deselect();
      }
    }

    public override void OnRightClick(PointerEventData data) {
      this.Abort();
    }

    public override void OnAbort() {
      Game.instance.selector.Deselect();
    }
  }
}
