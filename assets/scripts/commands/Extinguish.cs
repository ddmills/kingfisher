using UnityEngine;

namespace Entity.Command {
  public class Extinguish : Command {
    public override string label {
      get { return "Extinguish"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public override void Issue() {
      GetComponent<Fire>().flaggedForExtinction = true;
    }

    public override void Cancel() {
      Debug.Log("Cancel fire");
      GetComponent<Fire>().flaggedForExtinction = false;
    }
  }
}
