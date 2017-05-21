using King.Component;

namespace King.Actor.Command {
  public class Store : Command {
    public override string label {
      get { return "Store"; }
    }
    public override bool cancellable {
      get { return true; }
    }
    public Task.Task task;

    public override void OnIssue() {
      task = new Task.Store(Game.instance.taskQueue, GetComponent<ResourceManifestation>());
      task.OnCompleteE += OnTaskComplete;
    }

    private void OnTaskComplete() {
      Disable();
    }

    public override void OnCancel() {
      task.Cancel();
    }
  }
}
