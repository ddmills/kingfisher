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
      Extinguishable extinguishable = this.FindClosestExtinguishable();
      if (extinguishable != null) {
        return new Extinguish(this.gameObject, extinguishable);
      }

      Harvestable harvestable = this.FindClosestHarvestable();
      if (harvestable != null) {
        return new Harvest(this.gameObject, harvestable);
      }

      Plantable plantable = this.FindClosestPlantable();
      if (plantable != null) {
        return new Plant(this.gameObject, plantable);
      }

      return null;
    }

    private Extinguishable FindClosestExtinguishable() {
      return Utility.Entity.FindClosest<Extinguishable>(transform.position, (Extinguishable ob) => ob.flaggedForExtinction);
    }

    private Harvestable FindClosestHarvestable() {
      return Utility.Entity.FindClosest<Harvestable>(transform.position, (Harvestable ob) => ob.flaggedForHarvesting);
    }

    private Plantable FindClosestPlantable() {
      return Utility.Entity.FindClosest<Plantable>(transform.position, (Plantable ob) => ob.flaggedForPlanting);
    }

    private void BeginTask(Task task) {
      this.currentTask = task;
      Debug.Log(this.GetComponent<Selectable>().label + " is going to " + task.rootVerb);
      Debug.Log(this.GetComponent<Selectable>().label + " is currently " + task.presentVerb);
      this.currentTask.Start();
    }

    private void CancelTask(Task task) {
      this.currentTask.Cancel();
      this.currentTask = null;
    }

    public void MarkComplete(Task task) {
      this.currentTask = null;
      Debug.Log(this.GetComponent<Selectable>().label + " has " + task.pastVerb);
    }
  }
}
