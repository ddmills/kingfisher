using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.UI.Cursor;

namespace King.God.UI {
  public class BuildMenu : MonoBehaviour {

    public List<GameObject> buildable;
    public ContextSubMenu contextMenu;
    public GameObject itemTemplate;

    void Start () {
      PopulateBuildableList();
    }

    void PopulateBuildableList() {
      contextMenu.RemoveAllItems();

      foreach (GameObject entity in buildable) {
        GameObject item = (GameObject) Game.instance.Spawn(itemTemplate, Vector3.zero, Quaternion.identity);
        item.transform.SetParent(contextMenu.canvasGroup.transform);
        Button btn = item.GetComponent<Button>();
        item.GetComponentInChildren<Text>().text = entity.name;
        btn.onClick.AddListener(delegate {
          Game.instance.cursor.SetAction(new PlaceAction(entity));
          Game.instance.cursor.contextMenu.Hide();
        });
      }
    }
  }
}
