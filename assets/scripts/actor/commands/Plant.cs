namespace King.Actor.Command {
  public class Plant : Command {
    public override string label {
      get { return "Plant"; }
    }
    public override bool cancellable {
      get { return false; }
    }

    public Task.Task task;

    public override void OnIssue() {
      task = new Task.Plant(Game.instance.taskQueue, GetComponent<Behavior.Plantable>());
    }

    public override void OnCancel() {
      task.Cancel();
    }
  }
}
