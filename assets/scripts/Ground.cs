using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour, IPointerClickHandler {
  public void OnPointerClick(PointerEventData click) {
    Game.instance.cursor.Clicked(click);
  }
}
