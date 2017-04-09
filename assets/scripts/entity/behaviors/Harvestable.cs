using UnityEngine;

namespace Entity.Behavior {
  public class Harvestable : Workable {
    public bool harvested = false;
    public bool flaggedForHarvesting= false;
    public bool deleteOnHarvest = true;
    public GameObject resourcePrefab;

    void Start() {
      OnComplete += OnHarvested;
    }

    private void OnHarvested() {
      flaggedForHarvesting = false;
      Instantiate(resourcePrefab, transform.position, Quaternion.identity);
      if (deleteOnHarvest) {
        GetComponent<Deletable>().Delete();
      }
    }
  }
}
