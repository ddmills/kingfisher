using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public class Plant : Work {
    public override string rootVerb { get { return "plant"; } }
    public override string presentVerb { get { return "planting"; } }
    public override string pastVerb { get { return "planted"; } }

    public Plant(GameObject entity, Plantable plantable) : base(entity, plantable) {}

  }
}
