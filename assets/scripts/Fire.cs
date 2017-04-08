using UnityEngine;

public class Fire : MonoBehaviour {
  public float growthRate = 2.5f;
  public float maximumIntensity = 100f;
  public bool flaggedForExtinction = false;
  public bool deleteOnExtinction = true;
  public float intensity = 40f;
  private bool _extinguished = false;
  private ParticleSystem particles;

  public bool extinguished {
    get {
      return _extinguished;
    }
    set {
      _extinguished = value;
    }
  }

  void Start () {
    particles = GetComponentInChildren<ParticleSystem>();
  }

  void Update() {
    if (!extinguished) {
      intensity += Time.deltaTime * growthRate;
      if (intensity > maximumIntensity) {
        intensity = maximumIntensity;
      }
    }
    ParticleSystem.MainModule main = particles.main;
    main.startLifetime = intensity / 50f;
  }

  public void PutOut(float amount) {
    if (extinguished) return;
    intensity -= amount;
    if (intensity <= 0) {
      intensity = 0;
      extinguished = true;
      if (deleteOnExtinction) {
        this.GetComponent<Deletable>().Delete();
      }
    }
  }
}
