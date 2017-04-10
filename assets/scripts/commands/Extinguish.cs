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
      task = new Entity.Task.Extinguish(GetComponent<Extinguishable>());
      Game.instance.taskQueue.Push(task);
    }

    public override void Cancel() {
      Game.instance.taskQueue.Cancel(task);
    }
  }
}
