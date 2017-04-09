using UnityEngine;
using Entity.Behavior;

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
        return new Extinguish(this.gameObject, fire);
      }

      Harvestable harvestable = this.FindClosestHarvestable();
      if (harvestable != null) {
        return new Harvest(this.gameObject, harvestable);
      }
      return null;
    }

    private Fire FindClosestFire() {
      return Utility.Entity.FindClosest<Fire>(transform.position, (Fire ob) => ob.flaggedForExtinction);
    }

    private Harvestable FindClosestHarvestable() {
      return Utility.Entity.FindClosest<Harvestable>(transform.position, (Harvestable ob) => ob.flaggedForHarvest);
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
