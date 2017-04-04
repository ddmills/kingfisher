using System.Collections.Generic;
using UnityEngine;

namespace Entity.Task {
  public class Processor : MonoBehaviour {
    public List<Ability> abilities;
    public Task currentTask;

    void Start () {
      Move move = new Move(this.gameObject, new Vector3(3, 0, -3));
      this.BeginTask(move);
    }

    public bool CanPerform(Task task) {
      return false;
    }

    private void Update () {
      if (this.currentTask == null) {
        Fire fire = this.FindClosestFire();
        if (fire != null) {
          ExtinguishFire extinguishFire = new ExtinguishFire(this.gameObject, fire);
          this.BeginTask(extinguishFire);
        }
      } else {
        this.currentTask.Update();
      }
    }

    private Fire FindClosestFire() {
      Fire[] fires = Object.FindObjectsOfType<Fire>();
      Fire closest = null;
      float closestDistance = -1;

      foreach (Fire fire in fires) {
        float distance = Vector3.Distance(this.transform.position, fire.transform.position);

        if (!closest) {
          closest = fire;
          closestDistance = distance;
          continue;
        }

        if (distance <= closestDistance) {
          closest = fire;
          closestDistance = distance;
        }
      }

      return closest;
    }

    private void BeginTask(Task task) {
      this.currentTask = task;
      this.currentTask.Start();
      Debug.Log(this.name + " is going to " + task.rootVerb + "...");
      Debug.Log(this.name + " is currently " + task.presentVerb + "...");
    }

    private void CancelTask(Task task) {
      this.currentTask.Cancel();
      this.currentTask = null;
    }

    public void MarkComplete(Task task) {
      this.currentTask = null;
      Debug.Log(this.name + " has " + task.pastVerb + "...");
    }
  }
}
