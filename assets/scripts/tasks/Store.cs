using UnityEngine;

namespace Entity.Task {
  public class Store : Task {
    public override string rootVerb { get { return "store"; } }
    public override string presentVerb { get { return "storing"; } }
    public override string pastVerb { get { return "stored"; } }
    private Resource resource;
    private bool pickedUpResource = false;

    public Store(TaskQueue queue, Resource resource) : base(queue) {
      this.resource = resource;
    }

    public override void OnAddWorker(TaskProcessor worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(resource.transform.position, 1);
    }

    public override void OnRemoveWorker(TaskProcessor worker) {
      if (pickedUpResource) {
        pickedUpResource = false;
        Resource resource = worker.GetComponent<Inventory>().Remove();
        resource.transform.position = worker.transform.position;
      }
    }

    public override void Process(TaskProcessor worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      if (moveTo.reachedGoal) {
        if (!pickedUpResource) {
          worker.GetComponent<Inventory>().Add(resource);
          pickedUpResource = true;
          moveTo.SetGoal(new Vector3(12, 0, 20), 1);
        } else {
          Resource resource = worker.GetComponent<Inventory>().Remove();
          resource.transform.position = worker.transform.position;
          pickedUpResource = false;
          Complete();
        }
      }
    }

    private void DropResource() {
      if (workers.Count > 0) {
        TaskProcessor worker = workers[0];
        Resource resource = worker.GetComponent<Inventory>().Remove();
        resource.transform.position = worker.transform.position;
        pickedUpResource = false;
      }
    }

    public override bool CanBeWorkedBy(TaskProcessor worker) {
      Inventory inventory = worker.GetComponent<Inventory>();

      return worker.GetComponent<MoveTo>() != null
        && inventory != null
        && inventory.CanHold(resource);
    }
  }
}
