using UnityEngine;

namespace Entity.Behavior {
  public class Workable : MonoBehaviour {
    public delegate void CompleteHandler();
    public event CompleteHandler OnComplete;
    public bool flaggedForWork = false;
    public bool complete = false;
    public float workRemaining = 1f;

    public void Work(float amount) {
      if (complete) return;
      workRemaining -= amount;
      if (workRemaining <= 0) {
        complete = true;
        workRemaining = 0;
        flaggedForWork = false;
        if (OnComplete != null) {
          OnComplete();
        }
      }
    }
  }
}
