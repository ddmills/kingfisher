using UnityEngine;

namespace Entity.Command {
  public class Harvest : Command {
    public override void Execute (GameObject subject) {
      Debug.Log("harvessst");
    }
  }
}
