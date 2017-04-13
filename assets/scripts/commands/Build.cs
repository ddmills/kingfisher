namespace Entity.Command {
  public class Build : Command {
    public override string label {
      get { return "Build"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public Entity.Task.Task task;

    public override void OnIssue() {
      task = new Entity.Task.Build(Game.instance.taskQueue, GetComponent<Entity.Behavior.Buildable>());
    }

    public override void OnCancel() {
      task.Cancel();
      GetComponent<Deletable>().Delete();
    }
  }
}
