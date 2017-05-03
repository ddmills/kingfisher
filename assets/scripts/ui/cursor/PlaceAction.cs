using UnityEngine;
using UnityEngine.EventSystems;

namespace King.UI.Cursor {
  class PlaceAction : CursorAction {

    public override string name {
      get {
        return "place";
      }
    }
    protected GameObject blueprint;

    public PlaceAction(GameObject ob) {
      blueprint = (GameObject) Game.instance.Spawn(ob, Vector3.zero, Quaternion.identity);
      blueprint.transform.parent = Game.instance.cursor.cursor.transform;
      blueprint.transform.position = Game.instance.cursor.cursor.transform.position;
    }

    public override void OnLeftClick(PointerEventData click) {
      blueprint.transform.parent = null;
      King.Actor.Command.Build build = blueprint.GetComponent<King.Actor.Command.Build>();
      if (build) {
        build.Issue();
      }
      blueprint = null;
      Game.instance.cursor.SetAction(new SelectAction());
    }

    public override void OnRightClick(PointerEventData click) {
      Game.Destroy(blueprint);
      blueprint = null;
      Game.instance.cursor.SetAction(new SelectAction());
    }
  }
}
