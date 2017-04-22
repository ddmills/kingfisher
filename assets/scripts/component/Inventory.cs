using UnityEngine;

namespace King.Component {
  public class Inventory : MonoBehaviour {
    public Transform slot;
    public Resource resource;
    public bool disableResource = false;

    void Start() {

    }

    public Resource GetResource() {
      return resource;
    }

    public void Add(Resource resource) {
      this.resource = resource;

      resource.transform.parent = slot.transform;
      resource.transform.localPosition = new Vector3(0, 0, 0);
    }

    public Resource Remove() {
      Resource tmp = resource;
      resource.transform.parent = null;
      resource = null;
      return tmp;
    }

    public bool CanHold(Resource resource) {
      return this.resource == null;
    }
  }
}
