using Entity.Behavior;

namespace Entity.Task {
  public class Harvest : Work {
    public override string rootVerb { get { return "harvest"; } }
    public override string presentVerb { get { return "harvesting"; } }
    public override string pastVerb { get { return "harvested"; } }

    public Harvest(Harvestable harvestable) : base(harvestable) {}

    public override void Cancel() {
      workable.Reset();
    }
  }
}
