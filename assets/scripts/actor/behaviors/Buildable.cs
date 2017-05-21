using UnityEngine;
using King.Component;
using System.Collections.Generic;

namespace King.Actor.Behavior {
  public class Buildable : Workable {
    public GameObject buildingPrefab;
    public Dictionary<string, int> requiredResources; // = new Dictionary<string, int>();

    void Start() {
      OnComplete += OnBuilt;
    }

    private void OnBuilt() {
      Instantiate(buildingPrefab, transform.position, Quaternion.identity);
      GetComponent<Deletable>().Delete();
    }

    public bool ResourcesAreAvailable() {
      return false;
    }
  }
}
