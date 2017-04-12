using Entity.Behavior;

namespace Entity.Task {
  public class Extinguish : Work {
    public override string rootVerb { get { return "extinguish fire"; } }
    public override string presentVerb { get { return "extinguishing fire"; } }
    public override string pastVerb { get { return "extinguished fire"; } }
    public float priority = 2f;

    public Extinguish(TaskQueue queue, Extinguishable extinguishable) : base(queue, extinguishable) {
      maxWorkers = 4;
    }

    public override bool CanBeWorkedBy(TaskProcessor worker) {
      return worker.GetComponent<MoveTo>() != null;
    }

    public override float Weight(TaskProcessor worker) {
      return priority * base.Weight(worker);
    }
  }
}
