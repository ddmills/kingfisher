using UnityEngine;

namespace Entity.Task {
  public class Move : Task {
    public override string rootVerb { get { return "move"; } }
    public override string presentVerb { get { return "moving"; } }
    public override string pastVerb { get { return "moved"; } }
    private MoveTo moveTo;
    private Vector3 goal;

    public Move(GameObject entity, Vector3 goal, float epsilon = .05f) : base(entity) {
      this.goal = goal;
      this.moveTo = this.entity.GetComponent<MoveTo>();
    }

    public override void Start() {
      this.moveTo.SetGoal(goal);
    }

    private void OnReachedGoal() {
      this.MarkComplete();
    }
  }
}
