using King.Actor.Behavior;

namespace King.Actor.Task {
  public class Build : Work {
    public override string rootVerb { get { return "plant"; } }
    public override string presentVerb { get { return "planting"; } }
    public override string pastVerb { get { return "planted"; } }

    public Build(TaskQueue queue, Buildable buildable) : base(queue, buildable) {}

    public override void OnCancel() {
      workable.Reset();
    }
  }
}
