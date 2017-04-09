namespace Entity.Command {
  public class Plant : Command {
    public override string label {
      get { return "Plant"; }
    }
    public override bool cancellable {
      get { return true; }
    }

    public Entity.Task.Task task;

    public override void Issue() {
      GetComponent<Entity.Behavior.Plantable>().flaggedForPlanting = true;
      task = new Entity.Task.Plant(GetComponent<Entity.Behavior.Plantable>());
      Game.instance.taskQueue.Push(task);
    }

    public override void Cancel() {
      GetComponent<Entity.Behavior.Plantable>().flaggedForPlanting = false;
      Game.instance.taskQueue.Cancel(task);
    }
  }
}
