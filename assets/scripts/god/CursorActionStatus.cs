using UnityEngine;
using UnityEngine.UI;

public class CursorActionStatus : MonoBehaviour {

  public Text text;

  void Start () {
    this.Refresh();
  }

  void Update () {
    this.Refresh();
  }

  void Refresh() {
    text.text = "Cursor mode: " + Game.instance.cursor.action.name;
  }
}
