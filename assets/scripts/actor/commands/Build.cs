using King.Component;

namespace King.Actor.Command {
  public class Build : Command {
    public override string label {
      get { return "Build"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public Task.Task task;

    public override void OnIssue() {
      task = new Task.Build(Game.instance.taskQueue, GetComponent<Behavior.Buildable>());
    }

    public override void OnCancel() {
      task.Cancel();
      GetComponent<Deletable>().Delete();
    }
  }
}
