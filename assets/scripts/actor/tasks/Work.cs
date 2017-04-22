using UnityEngine;
using King.Actor.Behavior;
using King.Component;

namespace King.Actor.Task {
  public abstract class Work : Task {
    protected Workable workable;
    protected float workRate = .2f;

    public Work(TaskQueue queue, Workable workable) : base(queue) {
      this.workable = workable;
    }

    public override void OnAddWorker(Worker worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(workable.transform.position, 2);
    }

    public override void OnRemoveWorker(Worker worker) {}

    public override void Process(Worker worker) {
      if (workable.complete) {
        Complete();
      } else if (worker.GetComponent<MoveTo>().reachedGoal) {
        // TODO:
        // - have worker provide the work rate
        workable.Work(workRate * Time.deltaTime);
      }
    }

    public override float Weight(Worker worker) {
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

    public override bool CanBeWorkedBy(Worker worker) {
      return worker.GetComponent<MoveTo>() != null;
    }
  }
}
