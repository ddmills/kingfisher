using UnityEngine;

namespace King.Component {
  public class Inventory : MonoBehaviour {
    public Transform slot;
    public Merchandise merchandise;

    public Merchandise GetMerchandise() {
      return merchandise;
    }

    public void Add(Merchandise merchandise) {
      this.merchandise = merchandise;

      merchandise.transform.parent = slot.transform;
      merchandise.transform.localPosition = new Vector3(0, 0, 0);
    }

    public Merchandise Remove() {
      Merchandise tmp = merchandise;
      merchandise.transform.parent = null;
      merchandise = null;
      return tmp;
    }

    public bool CanHold(Merchandise merchandise) {
      return this.merchandise == null;
    }
  }
}
