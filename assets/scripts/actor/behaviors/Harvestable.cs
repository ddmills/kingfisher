using UnityEngine;
using King.Component;

namespace King.Actor.Behavior {
  public class Harvestable : Workable {
    public bool deleteOnHarvest = true;
    public bool storeMerchandiseOnHarvest = true;
    public GameObject merchandisePrefab;

    void Start() {
      OnComplete += OnHarvested;
    }

    private void OnHarvested() {
      GameObject merchandise = (GameObject) Game.instance.Spawn(merchandisePrefab, transform.position, Quaternion.identity);
      if (storeMerchandiseOnHarvest) {
        // TODO: place on same queue as worker who did harvesting
        merchandise.GetComponent<King.Actor.Command.Store>().Issue();
      }
      if (deleteOnHarvest) {
        GetComponent<Deletable>().Delete();
      }
    }
  }
}
