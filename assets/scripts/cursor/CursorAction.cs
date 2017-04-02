using UnityEngine;

public abstract class CursorAction {
  abstract public string name { get; }
  abstract public void execute(Transform spot);
  abstract public void cancel(Transform spot);
}
