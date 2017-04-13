namespace Entity.Command {
  public class Harvest : Command {
    public override string label {
      get { return "Harvest"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public Entity.Task.Task task;

    public override void OnIssue() {
      task = new Entity.Task.Harvest(Game.instance.taskQueue, GetComponent<Entity.Behavior.Harvestable>());
    }

    public override void OnCancel() {
      task.Cancel();
    }
  }
}
