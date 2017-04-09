using UnityEngine;

namespace Entity.Behavior {
  class Tree : Harvestable {
    public GameObject logPrefab;
    protected override void Harvested() {
      Instantiate(logPrefab, transform.position, Quaternion.identity);
      base.Harvested();
    }
  }
}
