using UnityEngine;

namespace King.Component {
  public class Stockpile : MonoBehaviour {
    private Merchandise merchandise;
    public bool reserved = false;

    public bool CanAdd(Merchandise merchandise) {
      return !reserved && this.merchandise == null;
    }

    public void Add(Merchandise merchandise) {
      this.merchandise = merchandise;
      reserved = false;
      merchandise.transform.parent = transform;
      merchandise.transform.localPosition = Vector3.zero;
    }
  }
}
