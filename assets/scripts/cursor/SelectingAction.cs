using UnityEngine.EventSystems;

class SelectingAction : CursorAction {
  public override string name {
    get {
      return "select";
    }
  }

  public override void OnLeftClick(PointerEventData data) {
    Selectable selectable = data.pointerPress.GetComponent<Selectable>();
    if (selectable) {
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