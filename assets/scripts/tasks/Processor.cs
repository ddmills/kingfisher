using System.Collections.Generic;
using UnityEngine;

namespace Entity.Task {
  public class Processor : MonoBehaviour {
    public Task currentTask;

    private void Update () {
      if (this.currentTask == null) {
        Task task = this.GetNextTask();
        if (task != null) {
          this.BeginTask(task);
        }
      } else {
        this.currentTask.Update();
      }
    }

    private Task GetNextTask() {
      Fire fire = this.FindClosestFire();
      if (fire != null) {
        return new ExtinguishFire(this.gameObject, fire);
      }
      return null;
    }

    private Fire FindClosestFire() {
      Fire[] fires = Object.FindObjectsOfType<Fire>();
      Fire closest = null;
      float closestDistance = -1;

      foreach (Fire fire in fires) {
        if (fire.flaggedForExtinction) {
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
      }

      return closest;
    }

    private void BeginTask(Task task) {
      this.currentTask = task;
      Debug.Log(this.name + " is going to " + task.rootVerb + "...");
      Debug.Log(this.name + " is currently " + task.presentVerb + "...");
      this.currentTask.Start();
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
