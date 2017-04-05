using UnityEngine;

public abstract class CursorAction {
  abstract public string name { get; }
  abstract public void Execute(Transform spot);
  abstract public void Cancel(Transform spot);
}
