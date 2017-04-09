using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public abstract class Work : Task {
    private MoveTo moveTo;
    protected Workable workable;
    private float workRate = .2f;

    public Work(Workable workable) {
      this.workable = workable;
    }

    public override void Start(GameObject entity) {
      base.Start(entity);
      moveTo = entity.GetComponent<MoveTo>();
      moveTo.SetGoal(workable.transform.position, 2);
    }

    public override void Update() {
      if (workable.complete) {
        MarkComplete();
      } else if (this.moveTo.reachedGoal) {
        workable.Work(workRate * Time.deltaTime);
      }
    }
  }
}
