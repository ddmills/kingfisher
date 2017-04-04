using UnityEngine;

public class Fire : MonoBehaviour {
  public delegate void ExtinguishedHandler();
  public event ExtinguishedHandler OnExtinguish;
  public float startingIntensity = 50f;
  public float maximumIntensity = 100f;
  private float intensity;
  private bool _extinguished = false;
  public bool extinguished {
    get {
      return this._extinguished;
    }
    set {
      this._extinguished = value;
    }
  }

  void Start () {
    this.intensity = this.startingIntensity;
  }

  public void PutOut(float amount) {
    if (this.extinguished) return;
    this.intensity -= amount;
    if (this.intensity <= 0) {
      this.intensity = 0;
      this.extinguished = true;
      if (this.OnExtinguish != null) {
        Destroy(this.gameObject);
        this.OnExtinguish();
      }
    }
  }

  public bool IsExtinguished() {
    return this.extinguished;
  }
}
