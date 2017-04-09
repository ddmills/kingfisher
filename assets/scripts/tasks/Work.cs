using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public abstract class Work : Task {
    private MoveTo moveTo;
    private Workable workable;
    private float workRate = .2f;

    public Work(GameObject entity, Workable workable) : base(entity) {
      this.workable = workable;
      moveTo = entity.GetComponent<MoveTo>();
    }

    public override void Start() {
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
