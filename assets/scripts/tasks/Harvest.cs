using Entity.Behavior;

namespace Entity.Task {
  public class Harvest : Work {
    public override string rootVerb { get { return "harvest"; } }
    public override string presentVerb { get { return "harvesting"; } }
    public override string pastVerb { get { return "harvested"; } }

    public Harvest(TaskQueue queue, Harvestable harvestable) : base(queue, harvestable) {
      maxWorkers = 2;
    }

    public override void OnCancel() {
      workable.Reset();
    }
  }
}
