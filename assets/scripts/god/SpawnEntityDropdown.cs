using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEntityDropdown : MonoBehaviour {

  private GameObject selected;
  public List<GameObject> spawnable;
  public Dropdown dropdown;

  void Start () {
    this.PopulateEntityList();
  }

  public void OnSelect(int index) {
    this.selected = index > 0 ? this.spawnable[index - 1] : null;
    if (this.selected) {
      Game.instance.cursor.action = new GodSpawnAction(this.selected);
    }
  }

  void PopulateEntityList() {
    this.dropdown.ClearOptions();

    List<string> names = new List<string>() { "spawn" };
    foreach (GameObject entity in this.spawnable) {
      names.Add(entity.name);
    }

    this.dropdown.AddOptions(names);
  }
}
