using UnityEngine;
using UnityEngine.AI;

namespace King.Component {
  public class MoveTo : MonoBehaviour {
    private Vector3 goal;
    private float epsilon = .05f;
    private NavMeshAgent agent;
    public bool reachedGoal {
      get {
        return distance <= epsilon;
      }
    }
    public float distance {
      get {
        return Vector3.Distance(transform.position, goal);
      }
    }

    void Start () {
      agent = GetComponent<NavMeshAgent>();
    }

    public void SetGoal(Vector3 goal, float epsilon = .05f) {
      this.epsilon = epsilon;
      this.goal = goal;
      agent.SetDestination(goal);
    }

    void Update () {
      if (reachedGoal) {
        agent.isStopped = true;
      } else {
        agent.isStopped = false;
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

    public bool CanReach(Vector3 position) {
      NavMeshPath path = new NavMeshPath();
      agent.CalculatePath(position, path);
      return path.status == NavMeshPathStatus.PathComplete;
    }
  }
}
