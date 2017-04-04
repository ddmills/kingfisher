using UnityEngine;

namespace Entity.Task {
  public class ExtinguishFire : Task {
    public override string rootVerb { get { return "extinguish fire"; } }
    public override string presentVerb { get { return "extinguishing fire"; } }
    public override string pastVerb { get { return "extinguished fire"; } }
    private MoveTo moveTo;
    private Fire fire;
    private bool reachedFire = false;
    private float fireExtinguishingRate = 25f;

    public ExtinguishFire(GameObject entity, Fire fire) : base(entity) {
      this.fire = fire;
      this.moveTo = this.entity.GetComponent<MoveTo>();
      this.moveTo.SetGoal(fire.transform.position, 2);
    }

    public override void Start() {
      this.moveTo.Begin();
      this.fire.OnExtinguish += this.MarkComplete;
      this.moveTo.OnReachedGoal += this.OnReachedFire;
    }

    public override void Update() {
      if (this.fire.extinguished) {
        this.MarkComplete();
      }

      if (this.reachedFire) {
        this.fire.PutOut(this.fireExtinguishingRate * Time.deltaTime);
      }
    }

    private void OnReachedFire() {
      this.reachedFire = true;
    }

    public override void Cancel() {
      this.moveTo.Pause();
    }

    public override void MarkComplete() {
      this.moveTo.Pause();
      base.MarkComplete();
    }
  }
}
