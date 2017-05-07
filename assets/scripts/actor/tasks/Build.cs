using King.Actor.Behavior;

namespace King.Actor.Task {
  public class Build : Work {
    public override string rootVerb { get { return "build"; } }
    public override string presentVerb { get { return "building"; } }
    public override string pastVerb { get { return "built"; } }

    public Build(TaskQueue queue, Buildable buildable) : base(queue, buildable) {}

    public override void OnCancel() {
      workable.Reset();
    }
  }
}
