using UnityEngine;
using UnityEngine.EventSystems;

class GodSpawnAction : CursorAction {

  public override string name {
    get {
      return "god spawn";
    }
  }
  protected GameObject ob;

  public GodSpawnAction(GameObject ob) {
    this.ob = ob;
    GameObject bp = Game.instance.cursor.blueprint;

    if (ob.GetComponent<MeshFilter>()) {
      bp.transform.localScale = ob.transform.localScale;
      bp.transform.rotation = ob.transform.rotation;
      bp.GetComponentInChildren<MeshRenderer>().enabled = true;

      bp.GetComponent<MeshFilter>().mesh = ob.GetComponent<MeshFilter>().sharedMesh;
    }
  }

  public override void OnLeftClick(PointerEventData click) {
    Quaternion qt = Game.instance.cursor.blueprint.transform.rotation;
    Game.instance.Spawn(this.ob, click.pointerPressRaycast.worldPosition, qt);
  }

  public override void OnRightClick(PointerEventData click) {
    Game.instance.cursor.blueprint.GetComponentInChildren<MeshRenderer>().enabled = false;
    Game.instance.cursor.SetAction(new SelectingAction());
  }
}