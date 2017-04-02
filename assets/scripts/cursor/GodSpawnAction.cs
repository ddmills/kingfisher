using UnityEngine;

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

    bp.transform.localScale = ob.transform.localScale;
    bp.transform.rotation = ob.transform.rotation;
    bp.GetComponentInChildren<MeshRenderer>().enabled = true;

    bp.GetComponent<MeshFilter>().mesh = ob.GetComponent<MeshFilter>().sharedMesh;
  }

  public override void execute(Transform spot) {
    Quaternion qt = Game.instance.cursor.blueprint.transform.rotation;
    Game.instance.Spawn(this.ob, spot.position, qt);
  }

  public override void cancel(Transform spot) {
    Game.instance.cursor.blueprint.GetComponentInChildren<MeshRenderer>().enabled = false;
    Game.instance.cursor.action = new SelectingAction();
  }
}