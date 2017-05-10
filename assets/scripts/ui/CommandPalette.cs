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
      if (target == null) return;
      Command[] commands = target.GetComponents<Command>();

      foreach (Command command in commands) {
        command.OnStateChangeE += RefreshAllButtons;
        if (command.visible && !command.issued && command.enabled) {
          Button btn = Instantiate(commandButtonPrefab);
          btn.transform.SetParent(this.transform);
          btn.GetComponentInChildren<Text>().text = command.label;
          btn.onClick.AddListener(delegate {
            command.Issue();
          });
        }

        if (command.issued && command.cancellable && command.enabled) {
          Button btn = Instantiate(commandButtonPrefab);
          btn.transform.SetParent(this.transform);
          btn.GetComponentInChildren<Text>().text = "Cancel " + command.label;
          btn.onClick.AddListener(delegate {
            command.Cancel();
          });
        }
      }
    }

    private void RemoveAllButtons() {
      foreach (Transform child in this.transform) {
        Destroy(child.gameObject);
        Command[] commands = target.GetComponents<Command>();
        foreach (Command command in commands) {
          command.OnStateChangeE += RefreshAllButtons;
        }
      }
    }
  }
}
