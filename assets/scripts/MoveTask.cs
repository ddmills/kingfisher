using UnityEngine;
using UnityEngine.AI;

public class MoveTask : Task {
  public override string rootVerb { get { return "move"; } }
  public override string presentVerb { get { return "moving"; } }
  public override string pastVerb { get { return "moved"; } }
  public Vector3 goal;
  public float epsilon;
  private NavMeshAgent agent;

  public MoveTask(GameObject entity) : base(entity) {
    this.agent = this.entity.GetComponent<NavMeshAgent>();
  }

  public void SetGoal(Vector3 goal, float epsilon = .05f) {
    this.goal = goal;
    this.epsilon = epsilon;
  }

  public override void Update() {
    if (this.agent.remainingDistance <= this.epsilon) {
      this.agent.isStopped = true;
      this.MarkComplete();
    }
  }

  public override void Start() {
    this.agent.SetDestination(this.goal);
  }

  public override void Cancel() {
    this.agent.isStopped = true;
  }
}
