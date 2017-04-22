using UnityEngine;
using UnityEngine.UI;
using King.Actor.Command;

namespace King {
  public class CommandPalette : MonoBehaviour {
    public Button commandButtonPrefab;
    private GameObject target;

    void Start () {
      Game.instance.selector.OnSelect += OnObjectSelected;
      Game.instance.selector.OnDeselect += OnObjectDeselected;
      RemoveAllButtons();
    }

    public void OnObjectSelected(GameObject selected) {
      target = selected;
      RefreshAllButtons();
    }

    public void OnObjectDeselected(GameObject deselected) {
      RemoveAllButtons();
    }

    public void RefreshAllButtons() {
      this.RemoveAllButtons();
      Command[] commands = target.GetComponents<Command>();
      foreach (Command command in commands) {
        if (command.visible && !command.issued) {
          Button btn = Instantiate(commandButtonPrefab);
          btn.transform.SetParent(this.transform);
          btn.GetComponentInChildren<Text>().text = command.label;
          btn.onClick.AddListener(delegate {
            command.Issue();
            RefreshAllButtons();
          });
        }

        if (command.issued && command.cancellable) {
          Button btn = Instantiate(commandButtonPrefab);
          btn.transform.SetParent(this.transform);
          btn.GetComponentInChildren<Text>().text = "Cancel " + command.label;
          btn.onClick.AddListener(delegate {
            command.Cancel();
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
}
