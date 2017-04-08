using UnityEngine;

namespace Entity.Command {
  public class Harvestable : Command {
    public override string label {
      get { return "Harvest"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public override void Issue() {
      Debug.Log("harvest " + this.name);
    }
  }
}
