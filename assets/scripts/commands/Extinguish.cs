using Entity.Behavior;

namespace Entity.Command {
  public class Extinguish : Command {
    public override string label {
      get { return "Extinguish"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public Entity.Task.Task task;

    public override void Issue() {
      task = new Entity.Task.Extinguish(Game.instance.taskQueue, GetComponent<Extinguishable>());
    }

    public override void Cancel() {
      task.Cancel();
    }
  }
}
