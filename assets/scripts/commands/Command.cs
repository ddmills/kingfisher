using UnityEngine;

namespace Entity.Command {

  public abstract class Command : MonoBehaviour {
    public bool visible = true;
    public abstract string label { get; }
    public virtual void Issue() {}
  }
}
