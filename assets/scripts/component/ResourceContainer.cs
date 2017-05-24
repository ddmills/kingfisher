using UnityEngine;
using System.Collections.Generic;

namespace King.Component {
  public class ResourceContainer : MonoBehaviour {
    public Transform slot;
    public Resource resource;
    public int quantity;
    private GameObject manifestation;

    public void Add(Resource resource, int quantity = 1) {
      if (this.resource == null) {
        this.resource = resource;
        UpdateSlot();
      }
      this.quantity += quantity;
    }

    private void UpdateSlot() {
      if (slot == null) {
        return;
      }

      if (this.resource != null) {
        manifestation = resource.Manifest(Vector3.zero);
        manifestation.transform.parent = slot.transform;
        manifestation.transform.localPosition = new Vector3(0, 0, 0);
      } else {
        Game.instance.Delete(manifestation);
      }
    }

    public void Transfer(ResourceContainer other) {
      other.Add(resource, quantity);
      quantity = 0;
      resource = null;
      UpdateSlot();
    }

    public List<GameObject> Disperse(Vector3 position, int radius = 1) {
      List<GameObject> manifestations = new List<GameObject>();
      for (int i = 0; i < quantity; i++) {
        Vector2 rand = Random.insideUnitCircle * radius;
        position.x += rand.x;
        position.z += rand.y;
        manifestations.Add(resource.Manifest(position));
      }
      return manifestations;
    }

    public bool CanHold(Resource resource, int quantity) {
      return this.resource.GetType().Equals(resource.GetType());
    }
  }
}
