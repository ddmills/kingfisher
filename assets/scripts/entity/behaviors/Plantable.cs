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
      GameObject inst = Instantiate(plantPrefab, transform.position, Quaternion.identity);
      Growable growable = inst.GetComponent<Growable>();
      if (growable) {
        growable.growth = 0;
      }

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
