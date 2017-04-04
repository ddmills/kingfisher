using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {
  public delegate void ReachedGoalHandler();
  public event ReachedGoalHandler OnReachedGoal;
  private Vector3 goal;
  private float epsilon = .05f;
  private NavMeshAgent agent;
  private bool finished = false;

  void Start () {
    this.agent = GetComponent<NavMeshAgent>();
  }

  public void SetGoal(Vector3 goal, float epsilon = .05f) {
    this.agent.destination = goal;
    this.epsilon = epsilon;
    this.agent.isStopped = true;
    this.finished = false;
  }

  public void Begin() {
    this.agent.isStopped = false;
    this.finished = false;
  }

  public void Pause() {
    this.agent.isStopped = true;
  }

  void Update () {
    if (!this.finished && this.agent.remainingDistance <= this.epsilon) {
      this.agent.isStopped = true;
      this.finished = true;
      if (this.OnReachedGoal != null) {
        this.OnReachedGoal();
      }
    }
  }
}
