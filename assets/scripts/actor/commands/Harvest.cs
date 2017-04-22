namespace King.Actor.Command {
  public class Harvest : Command {
    public override string label {
      get { return "Harvest"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public Task.Task task;

    public override void OnIssue() {
      task = new Task.Harvest(Game.instance.taskQueue, GetComponent<Behavior.Harvestable>());
    }

    public override void OnCancel() {
      task.Cancel();
    }
  }
}
