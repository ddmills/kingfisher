using UnityEngine;

namespace Entity.Task {
  public class Extinguish : Task {
    public override string rootVerb { get { return "extinguish fire"; } }
    public override string presentVerb { get { return "extinguishing fire"; } }
    public override string pastVerb { get { return "extinguished fire"; } }
    private MoveTo moveTo;
    private Fire fire;
    private float fireExtinguishingRate = 25f;

    public Extinguish(GameObject entity, Fire fire) : base(entity) {
      this.fire = fire;
      moveTo = entity.GetComponent<MoveTo>();
    }

    public override void Start() {
      this.moveTo.SetGoal(fire.transform.position, 2);
    }

    public override void Update() {
      if (fire.extinguished) {
        MarkComplete();
      } else if (moveTo.reachedGoal) {
        fire.Extinguish(fireExtinguishingRate * Time.deltaTime);
      }
    }
  }
}
