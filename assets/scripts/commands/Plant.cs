namespace Entity.Command {
  public class Plant : Command {
    public override string label {
      get { return "Plant"; }
    }
    public override bool cancellable {
      get { return false; }
    }

    public Entity.Task.Task task;

    public override void OnIssue() {
      task = new Entity.Task.Plant(Game.instance.taskQueue, GetComponent<Entity.Behavior.Plantable>());
    }

    public override void OnCancel() {
      task.Cancel();
    }
  }
}
