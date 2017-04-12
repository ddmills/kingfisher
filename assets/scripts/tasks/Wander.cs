using Entity.Behavior;

namespace Entity.Task {
  public class Wander : Task {
    public override string rootVerb { get { return "wander"; } }
    public override string presentVerb { get { return "wandering"; } }
    public override string pastVerb { get { return "wandered"; } }

    public Wander(TaskQueue queue) : base(queue) {}

    public override void OnAddWorker(TaskProcessor worker) {
      worker.GetComponent<Wanderable>().Wander();
    }

    public override void OnRemoveWorker(TaskProcessor worker) {
      worker.GetComponent<Wanderable>().Stop();
    }

    public override bool CanBeWorkedBy(TaskProcessor worker) {
      return worker.GetComponent<Wanderable>() != null;
    }

    public override float Weight(TaskProcessor worker) {
      return .1f;
    }
  }
}
