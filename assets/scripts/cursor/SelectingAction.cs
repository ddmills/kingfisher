using UnityEngine;

class SelectingAction : CursorAction {
  public override string name {
    get {
      return "select";
    }
  }

  public override void Execute(Transform spot) {
    if (Game.instance.selector.TrySelect()) {
      GameObject ob = Game.instance.selector.selected.gameObject;
      Game.instance.cursor.action = new GodSpawnAction(ob);
    }
  }

  public override void Cancel(Transform spot) {
    Game.instance.selector.Deselect();
  }
}