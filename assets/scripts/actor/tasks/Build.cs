using King.Actor.Behavior;
using King.Component;

namespace King.Actor.Task {
  public class Build : Work {
    public override string rootVerb { get { return "build"; } }
    public override string presentVerb { get { return "building"; } }
    public override string pastVerb { get { return "built"; } }
    private Buildable buildable;

    public Build(TaskQueue queue, Buildable buildable) : base(queue, buildable) {
      this.buildable = buildable;
    }

    public override void OnCancel() {
      workable.Reset();
    }

    public override bool CanBeWorkedBy(Worker worker) {
      return worker.GetComponent<MoveTo>() != null
        && buildable.ResourcesAreAvailable();
    }
  }
}
