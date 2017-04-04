using UnityEngine;

public class MoveTask : Task {
  public override string rootVerb { get { return "move"; } }
  public override string presentVerb { get { return "moving"; } }
  public override string pastVerb { get { return "moved"; } }
  private MoveTo moveTo;

  public MoveTask(GameObject entity, Vector3 goal, float epsilon = .05f) : base(entity) {
    this.moveTo = this.entity.GetComponent<MoveTo>();
    this.moveTo.SetGoal(goal);
  }

  public override void Start() {
    this.moveTo.Begin();
    this.moveTo.ReachedGoal += this.MarkComplete;
  }

  public override void Cancel() {
    this.moveTo.Pause();
  }
}
