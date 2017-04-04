using UnityEngine;
using UnityEngine.UI;

namespace God.UI {
  public class CursorActionStatusLabel : MonoBehaviour {

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
}
