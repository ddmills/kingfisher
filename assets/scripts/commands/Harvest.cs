namespace Entity.Command {
  public class Harvest : Command {
    public override string label {
      get { return "Harvest"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public override void Issue() {
      GetComponent<Entity.Behavior.Harvestable>().flaggedForHarvesting = true;
    }

    public override void Cancel() {
      GetComponent<Entity.Behavior.Harvestable>().flaggedForHarvesting = false;
    }
  }
}
