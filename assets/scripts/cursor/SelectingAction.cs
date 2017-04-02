using UnityEngine;

class SelectingAction : CursorAction {
  public override void execute(Transform spot) {
    if (Game.instance.selector.TrySelect()) {
      GameObject ob = Game.instance.selector.selected.gameObject;
      Game.instance.cursor.action = new GodSpawnAction(ob);
    }
  }

  public override void cancel(Transform spot) {
    Game.instance.selector.Unselect();
  }
}