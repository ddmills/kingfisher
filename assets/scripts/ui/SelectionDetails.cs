using UnityEngine;
using UnityEngine.UI;

public class SelectionDetails : MonoBehaviour {
  public Text label;

  void Start () {
    Game.instance.selector.OnSelect += OnObjectSelected;
    Game.instance.selector.OnDeselect += OnObjectDeselected;
  }

  public void OnObjectSelected(GameObject selected) {
    this.label.text = selected.name;
  }

  public void OnObjectDeselected(GameObject deselected) {
    this.label.text = "";
  }
}
