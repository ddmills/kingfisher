using King.Component;

namespace King.Actor.Task {
  public class Store : Task {
    public override string rootVerb { get { return "store"; } }
    public override string presentVerb { get { return "storing"; } }
    public override string pastVerb { get { return "stored"; } }
    private Resource resource;
    private bool pickedUpResource = false;
    private Stockpile stockpile;

    public Store(TaskQueue queue, Resource resource) : base(queue) {
      this.resource = resource;
    }

    public override void OnAddWorker(Worker worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(resource.transform.position, 1);
    }

    public override void OnRemoveWorker(Worker worker) {
      if (pickedUpResource) {
        pickedUpResource = false;
        Resource resource = worker.GetComponent<Inventory>().Remove();
        resource.transform.position = worker.transform.position;
      }
    }

    private Stockpile FindNearestStockpile() {
      return King.Utility.Search.FindClosest<Stockpile>(resource.transform.position);
    }

    public override void Process(Worker worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      if (moveTo.reachedGoal) {
        if (!pickedUpResource) {
          worker.GetComponent<Inventory>().Add(resource);
          pickedUpResource = true;
          moveTo.SetGoal(stockpile.transform.position, 1);
        } else {
          Resource resource = worker.GetComponent<Inventory>().Remove();
          resource.transform.position = stockpile.transform.position;
          pickedUpResource = false;
          Complete();
        }
      }
    }

    private void DropResource() {
      if (workers.Count > 0) {
        Worker worker = workers[0];
        Resource resource = worker.GetComponent<Inventory>().Remove();
        resource.transform.position = worker.transform.position;
        pickedUpResource = false;
      }
    }

    public override bool CanBeWorkedBy(Worker worker) {
      Inventory inventory = worker.GetComponent<Inventory>();
      if (stockpile == null) {
        stockpile = FindNearestStockpile();
      }

      return worker.GetComponent<MoveTo>() != null
        && inventory != null
        && stockpile != null
        && inventory.CanHold(resource);
    }
  }
}
