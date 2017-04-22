using UnityEngine;
using King.Component;

namespace King.Actor.Behavior {
  public class Buildable : Workable {
    public GameObject buildingPrefab;

    void Start() {
      OnComplete += OnBuilt;
    }

    private void OnBuilt() {
      Instantiate(buildingPrefab, transform.position, Quaternion.identity);
      GetComponent<Deletable>().Delete();
    }
  }
}
