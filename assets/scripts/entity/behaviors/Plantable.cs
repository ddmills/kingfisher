using UnityEngine;

namespace Entity.Behavior {
  public class Plantable : Workable {
    public GameObject plantPrefab;

    void Start() {
      OnComplete += OnPlanted;
    }

    private void OnPlanted() {
      GameObject inst = Instantiate(plantPrefab, transform.position, Quaternion.identity);
      Growable growable = inst.GetComponent<Growable>();
      if (growable) {
        growable.growth = 0;
      }
    }
  }
}
