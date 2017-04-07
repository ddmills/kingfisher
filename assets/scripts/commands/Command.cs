using UnityEngine;

namespace Entity.Command {

  public abstract class Command : ScriptableObject {
    public abstract void Execute(GameObject subject);
  }
}
