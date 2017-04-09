using UnityEngine;

namespace Entity.Behavior {
  public class Plantable : Workable {
    public bool flaggedForPlanting = false;
    public GameObject plantPrefab;

    void Start() {
      OnComplete += OnPlanted;
    }

    private void OnPlanted() {
      flaggedForPlanting = false;
      GameObject inst = Instantiate(plantPrefab, transform.position, Quaternion.identity);
      Growable growable = inst.GetComponent<Growable>();
      if (growable) {
        growable.growth = 0;
      }
    }
  }
}
