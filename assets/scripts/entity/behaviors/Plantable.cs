using UnityEngine;

namespace Entity.Behavior {
  public class Plantable : MonoBehaviour {
    public bool flaggedForPlanting = false;
    public bool planted = false;
    public GameObject plantPrefab;

    public void Plant() {
      OnPlanted();
    }

    private void OnPlanted() {
      planted = true;
      flaggedForPlanting = false;
      Instantiate(plantPrefab, transform.position, Quaternion.identity);
      Entity.Command.Plant plant = GetComponent<Entity.Command.Plant>();
      if (plant) {
        plant.visible = false;
        plant.issued = false;
      }
    }

    public void OnHarvested() {

    }
  }
}
