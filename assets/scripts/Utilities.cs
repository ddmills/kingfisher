using System;
using UnityEngine;

namespace Utility {
  public class Entity {
    public static T FindClosest<T>(Vector3 point, Func<T, bool> Test = null) where T : MonoBehaviour {
      T[] monos = UnityEngine.Object.FindObjectsOfType<T>();
      T closest = null;
      float closestDistance = -1;

      foreach (T mono in monos) {
        if (Test != null && !Test(mono)) {
          continue;
        }

        float distance = Vector3.Distance(point, mono.transform.position);

        if (!closest) {
          closest = mono;
          closestDistance = distance;
          continue;
        }

        if (distance <= closestDistance) {
          closest = mono;
          closestDistance = distance;
        }
      }

      return closest;
    }
  }
}