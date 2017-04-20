namespace Entity.Command {
  public class Store : Command {
    public override string label {
      get { return "Store"; }
    }
    public override bool cancellable {
      get { return true; }
    }
    public Entity.Task.Task task;

    public override void OnIssue() {
      task = new Entity.Task.Store(Game.instance.taskQueue, GetComponent<Resource>());
    }

    public override void OnCancel() {
      task.Cancel();
    }
  }
}
