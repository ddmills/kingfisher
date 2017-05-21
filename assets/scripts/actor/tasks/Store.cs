using King.Component;

namespace King.Actor.Task {
  public class Store : Task {
    public override string rootVerb { get { return "store"; } }
    public override string presentVerb { get { return "storing"; } }
    public override string pastVerb { get { return "stored"; } }
    private ResourceManifestation resource;
    private bool pickedUpResource = false;
    private bool storedResource = false;
    private Stockpile stockpile;

    public Store(TaskQueue queue, ResourceManifestation resource) : base(queue) {
      this.resource = resource;
    }

    public override void OnAddWorker(Worker worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(resource.transform.position, 1);
      // resource.ReserveRemaining(worker);
      resource.Reserve(worker, 1);
    }

    public override void OnRemoveWorker(Worker worker) {
      resource.Unreserve(worker);
      if (pickedUpResource) {
        pickedUpResource = false;
        ResourceManifestation resource = worker.GetComponent<Inventory>().Remove();
        resource.transform.position = worker.transform.position;
        resource.Unreserve(worker);
      // }
      // if (stockpile) {
      //   if (!storedMerchandise) {
      //     stockpile.Unreserve(merchandise);
      //   }
      //   stockpile = null;
      }
    }

    private Stockpile FindNearestStockpile() {
      return King.Utility.Search.FindClosest<Stockpile>(resource.transform.position, (stockpile) => {
        return stockpile.CanAdd(resource);
      });
    }

    public override void Process(Worker worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      if (moveTo.reachedGoal) {
        if (!pickedUpResource) {
          ResourceManifestation resource = this.resource.Redeem(worker);
          worker.GetComponent<Inventory>().Add(resource);
          pickedUpResource = true;
          moveTo.SetGoal(stockpile.transform.position, 1);
        } else {
      //     Merchandise merchandise = worker.GetComponent<Inventory>().Remove();
      //     stockpile.Add(merchandise);
      //     storedMerchandise = true;
      //     pickedUpMerchandise = false;
      //     merchandise.ReleaseBy(worker);
          Complete();
        }
      }
    }

    public override bool CanBeWorkedBy(Worker worker) {
      Inventory inventory = worker.GetComponent<Inventory>();
      if (stockpile == null) {
        stockpile = FindNearestStockpile();
        if (stockpile) {
          // stockpile.Reserve(merchandise);
        }
      }

      return worker.GetComponent<MoveTo>() != null
        && inventory != null
        && stockpile != null
        && inventory.CanHold(resource);
    }
  }
}
