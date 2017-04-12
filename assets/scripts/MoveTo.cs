using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {
  private Vector3 goal;
  private float epsilon = .05f;
  private NavMeshAgent agent;
  public bool reachedGoal {
    get {
      return this.distance <= this.epsilon;
    }
  }
  public float distance {
    get {
      return Vector3.Distance(this.transform.position, this.goal);
    }
  }

  void Start () {
    this.agent = GetComponent<NavMeshAgent>();
  }

  public void SetGoal(Vector3 goal, float epsilon = .05f) {
    this.epsilon = epsilon;
    this.goal = goal;
    this.agent.SetDestination(goal);
  }

  void Update () {
    if (this.reachedGoal) {
      this.agent.isStopped = true;
    } else {
      this.agent.isStopped = false;
    }
  }

  public void RandomInRange(Vector3 start, float range, int layerMask) {
    Vector2 flat = Random.insideUnitCircle * range;
    Vector3 direction = new Vector3(flat.x, 0, flat.y);
    // NavMeshHit navHit;
    // NavMesh.SamplePosition(direction, out navHit, range, layerMask);
    // Debug.Log(navHit.position);
    SetGoal(direction);
  }
}
