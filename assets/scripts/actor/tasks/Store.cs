using King.Component;

namespace King.Actor.Task {
  public class Store : Task {
    public override string rootVerb { get { return "store"; } }
    public override string presentVerb { get { return "storing"; } }
    public override string pastVerb { get { return "stored"; } }
    private Merchandise merchandise;
    private bool pickedUpMerchandise = false;
    private Stockpile stockpile;

    public Store(TaskQueue queue, Merchandise merchandise) : base(queue) {
      this.merchandise = merchandise;
    }

    public override void OnAddWorker(Worker worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      moveTo.SetGoal(merchandise.transform.position, 1);
    }

    public override void OnRemoveWorker(Worker worker) {
      if (pickedUpMerchandise) {
        pickedUpMerchandise = false;
        Merchandise merchandise = worker.GetComponent<Inventory>().Remove();
        merchandise.transform.position = worker.transform.position;
      }
      if (stockpile) {
        stockpile.reserved = false;
        stockpile = null;
      }
    }

    private Stockpile FindNearestStockpile(Merchandise merchandise) {
      return King.Utility.Search.FindClosest<Stockpile>(merchandise.transform.position, (stockpile) => {
        return stockpile.CanAdd(merchandise);
      });
    }

    public override void Process(Worker worker) {
      MoveTo moveTo = worker.GetComponent<MoveTo>();
      if (moveTo.reachedGoal) {
        if (!pickedUpMerchandise) {
          worker.GetComponent<Inventory>().Add(merchandise);
          pickedUpMerchandise = true;
          moveTo.SetGoal(stockpile.transform.position, 1);
        } else {
          Merchandise merchandise = worker.GetComponent<Inventory>().Remove();
          stockpile.Add(merchandise);
          pickedUpMerchandise = false;
          Complete();
        }
      }
    }

    public override bool CanBeWorkedBy(Worker worker) {
      Inventory inventory = worker.GetComponent<Inventory>();
      if (stockpile == null) {
        stockpile = FindNearestStockpile(merchandise);
        if (stockpile) {
          stockpile.reserved = true;
        }
      }

      return worker.GetComponent<MoveTo>() != null
        && inventory != null
        && stockpile != null
        && inventory.CanHold(merchandise);
    }
  }
}
