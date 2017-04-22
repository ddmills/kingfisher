using King.Actor.Behavior;

namespace King.Actor.Task {
  public class Wander : Task {
    public override string rootVerb { get { return "wander"; } }
    public override string presentVerb { get { return "wandering"; } }
    public override string pastVerb { get { return "wandered"; } }

    public Wander(TaskQueue queue) : base(queue) {}

    public override void OnAddWorker(Worker worker) {
      worker.GetComponent<Wanderable>().Wander();
    }

    public override void OnRemoveWorker(Worker worker) {
      worker.GetComponent<Wanderable>().Stop();
    }

    public override bool CanBeWorkedBy(Worker worker) {
      return worker.GetComponent<Wanderable>() != null;
    }

    public override float Weight(Worker worker) {
      return .1f;
    }
  }
}
