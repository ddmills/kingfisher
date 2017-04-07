using UnityEngine;

namespace Entity.Command {
  public class Extinguish : Command {
    public string text = "Extinguish";
    public override void Execute (GameObject subject) {
      subject.GetComponent<Fire>().flaggedForExtinction = true;
      // Debug.Log("harvessst");
    }
  }
}
