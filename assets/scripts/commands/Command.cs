using UnityEngine;

namespace Entity.Command {

  public abstract class Command : MonoBehaviour {
    public bool issued = false;
    public bool visible = true;
    public abstract string label { get; }
    public abstract bool cancellable { get; }
    public virtual void Issue() {}
    public virtual void Cancel() {}
  }
}
