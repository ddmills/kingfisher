using UnityEngine;

namespace Entity.Behavior {
  public class Harvestable : MonoBehaviour {
    public bool flaggedForHarvest = false;
    public bool harvested = false;
    public bool deleteOnHarvest = true;

    public void Harvest(float amount) {
      if (harvested) return;
      harvested = true;
      flaggedForHarvest = false;
      if (deleteOnHarvest) {
        GetComponent<Deletable>().Delete();
      }
    }
  }
}
