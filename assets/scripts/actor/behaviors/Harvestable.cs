using UnityEngine;
using King.Component;

namespace King.Actor.Behavior {
  public class Harvestable : Workable {
    public bool deleteOnHarvest = true;
    public bool storeResourceOnHarvest = true;
    public GameObject resourcePrefab;

    void Start() {
      OnComplete += OnHarvested;
    }

    private void OnHarvested() {
      GameObject resource = (GameObject) Game.instance.Spawn(resourcePrefab, transform.position, Quaternion.identity);
      if (storeResourceOnHarvest) {
        // TODO: place on same queue as worker who did harvesting
        resource.GetComponent<King.Actor.Command.Store>().Issue();
      }
      if (deleteOnHarvest) {
        GetComponent<Deletable>().Delete();
      }
    }
  }
}
