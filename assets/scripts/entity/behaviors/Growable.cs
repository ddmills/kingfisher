using UnityEngine;

namespace Entity.Behavior {
  public class Growable : MonoBehaviour {
    public float growth = .1f;
    public float growthRate = .2f;
    public float maxGrowth = 1f;

    public void Start() {
      transform.localScale = new Vector3(growth, growth, growth);
    }

    public void Update() {
      if (growth <= maxGrowth) {
        growth += Time.deltaTime * growthRate;
        transform.localScale = new Vector3(growth, growth, growth);
      }
    }
  }
}
