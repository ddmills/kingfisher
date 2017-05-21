using UnityEngine;

namespace King.Component {
  public class Inventory : MonoBehaviour {
    public Transform slot;
    public ResourceManifestation resource;

    public void Add(ResourceManifestation resource) {
      this.resource = resource;

      resource.transform.parent = slot.transform;
      resource.transform.localPosition = new Vector3(0, 0, 0);
    }

    public ResourceManifestation Remove() {
      ResourceManifestation tmp = resource;
      resource.transform.parent = null;
      resource = null;
      return tmp;
    }

    public bool CanHold(ResourceManifestation resource) {
      return this.resource == null;
    }
  }
}
