using UnityEngine;
using System.Collections.Generic;

namespace King.Component {
  public class ResourceMap : MonoBehaviour {
    [System.Serializable]
    public class ResourceEntry {
      public ResourceEntry(Resource resource, int count) {
        this.resource = resource;
        this.count = count;
      }

      public Resource resource;
      public int count;
    }

    public List<ResourceEntry> resources;

    public int Count(Resource resource) {
      ResourceEntry entry = Find(resource);
      return entry == null ? 0 : entry.count;
    }

    public bool Contains(Resource resource) {
      return Find(resource) != null;
    }

    public ResourceEntry Find(Resource resource) {
      return resources.Find(entry => entry.resource.Equals(resource));
    }

    public void Add(Resource resource, int count) {
      ResourceEntry entry = Find(resource);
      if (entry != null) {
        entry.count += count;
      } else {
        resources.Add(new ResourceEntry(resource, count));
      }
    }

    public ResourceEntry Remove(Resource resource) {
      ResourceEntry entry = Find(resource);
      resources.Remove(entry);
      return entry;
    }

    public ResourceEntry Remove(Resource resource, int count) {
      ResourceEntry entry = Find(resource);
      if (entry != null) {
         if (count < entry.count) {
          entry.count -= count;
          return new ResourceEntry(entry.resource, count);
        } else if (count == entry.count) {
          return entry;
        }
      }
      return null;
    }
  }
}
