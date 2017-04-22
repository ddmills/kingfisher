using UnityEngine;
using UnityEngine.EventSystems;

namespace King.World {
  public class Ground : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData click) {
      Game.instance.cursor.Clicked(click);
    }
  }
}
