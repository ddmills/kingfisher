using System.Collections;
using UnityEngine;
using King.Component;

namespace King.Actor.Behavior {
  public class Wanderable : MonoBehaviour {
    public MoveTo moveTo;
    public float wanderRadius;
    public float wanderDelay;
    private IEnumerator coroutine;

    void Start() {
      moveTo = GetComponent<MoveTo>();
    }

    public void Wander() {
      coroutine = GoToRandom();
      StartCoroutine(coroutine);
    }

    public void Stop() {
      Debug.Log("stop coroutin");
      StopCoroutine(coroutine);
    }

    private IEnumerator GoToRandom() {
      Debug.Log("in coroutine");
      while(true) {
        moveTo.RandomInRange(transform.position, wanderRadius, 1 << 9);
        yield return new WaitForSeconds(wanderDelay);
      }
    }
  }
}
