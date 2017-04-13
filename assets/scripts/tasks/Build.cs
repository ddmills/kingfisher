using Entity.Behavior;

namespace Entity.Task {
  public class Build : Work {
    public override string rootVerb { get { return "plant"; } }
    public override string presentVerb { get { return "planting"; } }
    public override string pastVerb { get { return "planted"; } }

    public Build(TaskQueue queue, Buildable buildable) : base(queue, buildable) {}

    public override bool CanBeWorkedBy(TaskProcessor worker) {
      return worker.GetComponent<MoveTo>() != null;
    }

    public override void OnCancel() {
      workable.Reset();
    }
  }
}
