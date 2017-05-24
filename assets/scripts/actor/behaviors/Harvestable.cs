using UnityEngine;
using King.Component;
using System.Collections.Generic;

namespace King.Actor.Behavior {
  public class Harvestable : Workable {
    public bool deleteOnHarvest = true;
    public bool storeResourcesOnHarvest = true;
    public ResourceContainer resources;

    void Start() {
      OnComplete += OnHarvested;
    }

    private void OnHarvested() {
      List<GameObject> manifestations = resources.Disperse(transform.position, 2);
      if (storeResourcesOnHarvest) {
        manifestations.ForEach(manifestation => {
          manifestation.GetComponent<King.Actor.Command.Store>().Issue();
        });
      }
      if (deleteOnHarvest) {
        GetComponent<Deletable>().Delete();
      }
    }
  }
}
