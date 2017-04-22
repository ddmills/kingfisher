using UnityEngine;
using King.Component;

namespace King.Actor.Task {
  public class Move : Task {
    public override string rootVerb { get { return "move"; } }
    public override string presentVerb { get { return "moving"; } }
    public override string pastVerb { get { return "moved"; } }
    private MoveTo moveTo;
    private Vector3 goal;

    public Move(TaskQueue queue, Vector3 goal, float epsilon = .05f) : base(queue) {
      this.goal = goal;
    }

    public override void OnAddWorker(Worker worker) {
      moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(goal);
    }

    private void OnReachedGoal() {
      this.Complete();
    }

    public override bool CanBeWorkedBy(Worker worker) {
      return worker.GetComponent<MoveTo>() != null;
    }
  }
}
