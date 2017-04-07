using UnityEngine;
using UnityEngine.UI;
using Entity.Command;

public class CommandsPanel : MonoBehaviour {
  public Button commandButtonPrefab;

  void Start () {
    Game.instance.selector.OnSelect += OnObjectSelected;
    Game.instance.selector.OnDeselect += OnObjectDeselected;
    this.RemoveAllButtons();
  }

  public void OnObjectSelected(GameObject selected) {
    this.RemoveAllButtons();
    Commandable commandable = selected.GetComponent<Commandable>();
    if (commandable) {
      foreach (Command command in commandable.commands) {
        Button btn = Instantiate(commandButtonPrefab);
        btn.transform.SetParent(this.transform);
        btn.GetComponentInChildren<Text>().text = command.name;
        btn.onClick.AddListener(delegate {
          command.Execute(selected);
        });
      }
    }
  }

  public void OnObjectDeselected(GameObject deselected) {
    this.RemoveAllButtons();
  }

  private void RemoveAllButtons() {
    foreach (Transform child in this.transform) {
      Destroy(child.gameObject);
    }
  }
}
