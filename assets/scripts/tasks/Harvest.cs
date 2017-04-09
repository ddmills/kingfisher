using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public class Harvest : Work {
    public override string rootVerb { get { return "harvest"; } }
    public override string presentVerb { get { return "harvesting"; } }
    public override string pastVerb { get { return "harvested"; } }

    public Harvest(GameObject entity, Harvestable harvestable) : base(entity, harvestable) {}

  }
}
