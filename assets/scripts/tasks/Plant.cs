using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public class Plant : Task {
    public override string rootVerb { get { return "plant"; } }
    public override string presentVerb { get { return "planting"; } }
    public override string pastVerb { get { return "planted"; } }
    private MoveTo moveTo;
    private Plantable plantable;
    private float harvestRate = 25f;

    public Plant(GameObject entity, Plantable plantable) : base(entity) {
      this.plantable = plantable;
      moveTo = entity.GetComponent<MoveTo>();
    }

    public override void Start() {
      moveTo.SetGoal(plantable.transform.position, 2);
    }

    public override void Update() {
      if (plantable.planted) {
        MarkComplete();
      } else if (this.moveTo.reachedGoal) {
        plantable.Plant();
      }
    }
  }
}
