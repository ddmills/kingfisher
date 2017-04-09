using UnityEngine;

namespace Entity.Task {
  public class Move : Task {
    public override string rootVerb { get { return "move"; } }
    public override string presentVerb { get { return "moving"; } }
    public override string pastVerb { get { return "moved"; } }
    private MoveTo moveTo;
    private Vector3 goal;

    public Move(Vector3 goal, float epsilon = .05f) {
      this.goal = goal;
    }

    public override void Start(GameObject entity) {
      base.Start(entity);
      moveTo = entity.GetComponent<MoveTo>();
      moveTo.SetGoal(goal);
    }

    private void OnReachedGoal() {
      this.MarkComplete();
    }
  }
}
