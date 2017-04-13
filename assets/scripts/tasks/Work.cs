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
      // TODO:
      // - factor in nav mesh distance to target ?

      if (workers.Count == 0) {
        return 2f;
      } if (workers.Contains(worker)) {
        return 3f - workable.workRemaining;
      } else {
        return 1 + workers.Count / maxWorkers;
      }
    }

    public override bool CanBeWorkedBy(TaskProcessor worker) {
      return worker.GetComponent<MoveTo>() != null;
    }
  }
}
