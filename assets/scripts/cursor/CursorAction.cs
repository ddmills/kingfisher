using UnityEngine.EventSystems;

public abstract class CursorAction {
  abstract public string name { get; }
  public virtual void Abort() {
    Game.instance.cursor.AbortAction();
  }
  public virtual void OnAbort() {}
  public virtual void OnLeftClick(PointerEventData data) {}
  public virtual void OnRightClick(PointerEventData data) {}
  public virtual void OnMiddleClick(PointerEventData data) {}
}
