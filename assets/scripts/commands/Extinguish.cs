using Entity.Behavior;

namespace Entity.Command {
  public class Extinguish : Command {
    public override string label {
      get { return "Extinguish"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public override void Issue() {
      GetComponent<Extinguishable>().flaggedForExtinction = true;
    }

    public override void Cancel() {
      GetComponent<Extinguishable>().flaggedForExtinction = false;
    }
  }
}
