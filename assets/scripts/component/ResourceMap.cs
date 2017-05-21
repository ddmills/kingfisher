using UnityEngine;
using System.Collections.Generic;

namespace King.Component {
  public class ResourceMap : MonoBehaviour {
    [System.Serializable]
    public class ResourceEntry {
      public ResourceEntry(Resource resource, int quantity) {
        this.resource = resource;
        this.quantity = quantity;
      }

      public Resource resource;
      public int quantity;
    }

    public List<ResourceEntry> resources;

    public int Count(Resource resource) {
      ResourceEntry entry = Find(resource);
      return entry == null ? 0 : entry.quantity;
    }

    public bool Contains(Resource resource) {
      return Find(resource) != null;
    }

    public ResourceEntry Find(Resource resource) {
      return resources.Find(entry => entry.resource.Equals(resource));
    }

    public void Add(Resource resource, int quantity) {
      ResourceEntry entry = Find(resource);
      if (entry != null) {
        entry.quantity += quantity;
      } else {
        resources.Add(new ResourceEntry(resource, quantity));
      }
    }

    public ResourceEntry Remove(Resource resource) {
      ResourceEntry entry = Find(resource);
      resources.Remove(entry);
      return entry;
    }

    public ResourceEntry Remove(Resource resource, int quantity) {
      ResourceEntry entry = Find(resource);
      if (entry != null) {
         if (quantity < entry.quantity) {
          entry.quantity -= quantity;
          return new ResourceEntry(entry.resource, quantity);
        } else if (quantity == entry.quantity) {
          return entry;
        }
      }
      return null;
    }
  }
}
