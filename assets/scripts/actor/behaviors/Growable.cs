using UnityEngine;
using System.Collections;

namespace King.Actor.Behavior {
  public class Growable : MonoBehaviour {
    public bool grown = false;
    public float growth = .1f;
    public float growthRate = .05f;
    public float growthDelay = 1f;
    public float maxGrowth = 1f;

    public void Start() {
      grown = growth >= maxGrowth;
      transform.localScale = new Vector3(growth, growth, growth);
      if (!grown) {
        StartCoroutine(GrowCoroutine());
      }
    }

    IEnumerator GrowCoroutine() {
      growth += growthRate;
      if (growth > maxGrowth) {
        growth = maxGrowth;
        grown = true;
      }
      transform.localScale = new Vector3(growth, growth, growth);
      if (growth < maxGrowth) {
        yield return new WaitForSeconds(growthDelay);
        StartCoroutine(GrowCoroutine());
      }
    }
  }
}
