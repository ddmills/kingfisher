using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.UI.Cursor;

namespace King.God.UI {
  public class SpawnEntityDropdown : MonoBehaviour {

    private GameObject selected;
    public List<GameObject> spawnable;
    public Dropdown dropdown;

    void Start () {
      PopulateEntityList();
    }

    public void OnSelect(int index) {
      selected = index > 0 ? spawnable[index - 1] : null;
      if (selected) {
        Game.instance.cursor.SetAction(new GodSpawnAction(selected));
        dropdown.value = 0;
      }
    }

    void PopulateEntityList() {
      dropdown.ClearOptions();

      List<string> names = new List<string>() { "spawn" };
      foreach (GameObject entity in spawnable) {
        names.Add(entity.name);
      }

      dropdown.AddOptions(names);
    }
  }
}
