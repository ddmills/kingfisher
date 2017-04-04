using UnityEngine;

public class Fire : MonoBehaviour {
  public delegate void ExtinguishedHandler();
  public event ExtinguishedHandler OnExtinguish;
  public float startingIntensity = 50f;
  public float maximumIntensity = 100f;
  private float intensity;
  private bool extinguished = false;

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
        this.OnExtinguish();
        Destroy(this.gameObject);
      }
    }
  }
}
