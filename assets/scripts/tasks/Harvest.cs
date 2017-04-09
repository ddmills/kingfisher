using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public class Harvest : Task {
    public override string rootVerb { get { return "harvest"; } }
    public override string presentVerb { get { return "harvesting"; } }
    public override string pastVerb { get { return "harvested"; } }
    private MoveTo moveTo;
    private Harvestable harvestable;
    private float harvestRate = 25f;

    public Harvest(GameObject entity, Harvestable harvestable) : base(entity) {
      this.harvestable = harvestable;
      moveTo = entity.GetComponent<MoveTo>();
    }

    public override void Start() {
      moveTo.SetGoal(harvestable.transform.position, 2);
    }

    public override void Update() {
      if (harvestable.harvested) {
        MarkComplete();
      } else if (this.moveTo.reachedGoal) {
        harvestable.Harvest(this.harvestRate * Time.deltaTime);
      }
    }
  }
}
