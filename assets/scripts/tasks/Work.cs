using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public abstract class Work : Task {
    protected Workable workable;
    protected float workRate = .2f;

    public Work(TaskQueue queue, Workable workable) : base(queue) {
      this.workable = workable;
    }

    public override void OnAddWorker(TaskProcessor worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(workable.transform.position, 2);
    }

    public override void OnRemoveWorker(TaskProcessor worker) {}

    public override void Process(TaskProcessor worker) {
      if (workable.complete) {
        Complete();
      } else if (worker.GetComponent<MoveTo>().reachedGoal) {
        // TODO:
        // - have worker provide the work rate
        workable.Work(workRate * Time.deltaTime);
      }
    }

    public override float Weight(TaskProcessor worker) {
      float remaining = (1 - workable.workRemaining) * 2 + 1;
      // TODO:
      // - check if moveTo can reach workable (in CanBeWorkedBy?)
      // - factor in nav mesh distance to target
      // - factor in number of people currently working on it (excluding worker)
      return remaining;
    }
  }
}
