using UnityEngine;
using UnityEngine.UI;
using Entity.Command;

public class CommandPalette : MonoBehaviour {
  public Button commandButtonPrefab;
  private GameObject target;

  void Start () {
    Game.instance.selector.OnSelect += OnObjectSelected;
    Game.instance.selector.OnDeselect += OnObjectDeselected;
    this.RemoveAllButtons();
  }

  public void OnObjectSelected(GameObject selected) {
    this.target = selected;
    this.RefreshAllButtons();
  }

  public void OnObjectDeselected(GameObject deselected) {
    this.RemoveAllButtons();
  }

  public void RefreshAllButtons() {
    this.RemoveAllButtons();
    Command[] commands = target.GetComponents<Command>();
    foreach (Command command in commands) {
      if (command.visible) {
        Button btn = Instantiate(commandButtonPrefab);
        btn.transform.SetParent(this.transform);
        btn.GetComponentInChildren<Text>().text = command.label;
        btn.onClick.AddListener(delegate {
          command.Issue();
          RefreshAllButtons();
        });
      }
    }
  }

  private void RemoveAllButtons() {
    foreach (Transform child in this.transform) {
      Destroy(child.gameObject);
    }
  }
}
