using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public abstract class Work : Task {
    protected Workable workable;
    private float workRate = .2f;

    public Work(TaskQueue queue, Workable workable) : base(queue) {
      this.workable = workable;
    }

    public override void OnAddWorker(TaskProcessor worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(workable.transform.position, 2);
    }

    public override void OnRemoveWorker(TaskProcessor worker) {
    }

    public override void Process(TaskProcessor worker) {
      if (workable.complete) {
        Complete();
      } else if (worker.GetComponent<MoveTo>().reachedGoal) {
        workable.Work(workRate * Time.deltaTime);
      }
    }
  }
}
