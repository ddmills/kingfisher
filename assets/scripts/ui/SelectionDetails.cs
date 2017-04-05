using UnityEngine;
using UnityEngine.UI;

public class SelectionDetails : MonoBehaviour {
  public Text label;

  void Start () {
    Game.instance.selector.OnSelect += OnObjectSelected;
    Game.instance.selector.OnDeselect += OnObjectDeselected;
  }

  void Update () {
  }

  public void OnObjectSelected(GameObject selected) {
    Debug.Log(selected.name + " selected");
    this.label.text = selected.name;
  }

  public void OnObjectDeselected(GameObject deselected) {
    Debug.Log(deselected.name + " deselected");
    this.label.text = "";
  }
}
