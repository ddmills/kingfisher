using UnityEngine;

namespace Entity.Behavior {
  public class Extinguishable : Workable {
    public float maximumIntensity = 1f;
    public bool flaggedForExtinction = false;
    public bool deleteOnExtinction = true;
    public float growthRate = .1f;
    public float intensity = .5f;
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
      OnComplete += OnExtinguished;
    }

    void Update() {
      if (!extinguished) {
        intensity += Time.deltaTime * growthRate;
        if (intensity > maximumIntensity) {
          intensity = maximumIntensity;
        }
      }

      ParticleSystem.MainModule main = particles.main;
      main.startLifetime = intensity * 2;
    }

    public void OnExtinguished() {
      if (deleteOnExtinction) {
        this.GetComponent<Deletable>().Delete();
      }
    }
  }
}
