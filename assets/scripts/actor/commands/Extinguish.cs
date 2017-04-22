using King.Actor.Behavior;

namespace King.Actor.Command {
  public class Extinguish : Command {
    public override string label {
      get { return "Extinguish"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public King.Actor.Task.Task task;

    public override void OnIssue() {
      task = new King.Actor.Task.Extinguish(Game.instance.taskQueue, GetComponent<Extinguishable>());
    }

    public override void OnCancel() {
      task.Cancel();
    }
  }
}
