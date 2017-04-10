namespace Entity.Command {
  public class Harvest : Command {
    public override string label {
      get { return "Harvest"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public Entity.Task.Task task;

    public override void Issue() {
      task = new Entity.Task.Harvest(GetComponent<Entity.Behavior.Harvestable>());
      Game.instance.taskQueue.Push(task);
    }

    public override void Cancel() {
      Game.instance.taskQueue.Cancel(task);
    }
  }
}
