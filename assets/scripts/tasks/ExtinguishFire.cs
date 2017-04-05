using UnityEngine;

namespace Entity.Task {
  public class ExtinguishFire : Task {
    public override string rootVerb { get { return "extinguish fire"; } }
    public override string presentVerb { get { return "extinguishing fire"; } }
    public override string pastVerb { get { return "extinguished fire"; } }
    private MoveTo moveTo;
    private Fire fire;
    private float fireExtinguishingRate = 25f;

    public ExtinguishFire(GameObject entity, Fire fire) : base(entity) {
      this.fire = fire;
      this.moveTo = this.entity.GetComponent<MoveTo>();
    }

    public override void Start() {
      this.moveTo.SetGoal(this.fire.transform.position, 2);
    }

    public override void Update() {
      if (this.fire.extinguished) {
        this.MarkComplete();
      } else if (this.moveTo.reachedGoal) {
        this.fire.PutOut(this.fireExtinguishingRate * Time.deltaTime);
      }
    }
  }
}
