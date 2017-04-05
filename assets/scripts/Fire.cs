using UnityEngine;

public class Fire : MonoBehaviour {
  public float growthRate = 2.5f;
  public float maximumIntensity = 100f;
  public bool flaggedForExtinction = true;
  public bool destroyOnExtinction = true;
  public float intensity = 40f;
  private bool _extinguished = false;
  private ParticleSystem particles;

  public bool extinguished {
    get {
      return this._extinguished;
    }
    set {
      this._extinguished = value;
    }
  }

  void Start () {
    this.particles = this.GetComponentInChildren<ParticleSystem>();
  }

  public void Update() {
    if (!this.extinguished) {
      this.intensity += Time.deltaTime * this.growthRate;
      if (this.intensity > this.maximumIntensity) {
        this.intensity = this.maximumIntensity;
      }
    }
    ParticleSystem.MainModule main = this.particles.main;
    main.startLifetime = this.intensity / 50f;
  }

  public void PutOut(float amount) {
    if (this.extinguished) return;
    this.intensity -= amount;
    if (this.intensity <= 0) {
      this.intensity = 0;
      this.extinguished = true;
      if (this.destroyOnExtinction) {
        Destroy(this.gameObject);
      }
    }
  }
}
