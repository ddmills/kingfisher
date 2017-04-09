namespace Entity.Command {
  public class Plant : Command {
    public override string label {
      get { return "Plant"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public override void Issue() {
      GetComponent<Entity.Behavior.Plantable>().flaggedForPlanting = true;
    }

    public override void Cancel() {
      GetComponent<Entity.Behavior.Plantable>().flaggedForPlanting = false;
    }
  }
}
