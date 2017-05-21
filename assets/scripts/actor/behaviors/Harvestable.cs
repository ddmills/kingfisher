using King.Component;

namespace King.Actor.Behavior {
  public class Harvestable : Workable {
    public bool deleteOnHarvest = true;
    public bool storeResourceOnHarvest = true;
    public Resource resource;
    public int resourceQuantity = 2;

    void Start() {
      OnComplete += OnHarvested;
    }

    private void OnHarvested() {
      ResourceManifestation manifestation = resource.Manifest(transform.position, resourceQuantity);
      if (storeResourceOnHarvest) {
        // TODO: place on same queue as worker who did harvesting
        manifestation.GetComponent<King.Actor.Command.Store>().Issue();
      }
      if (deleteOnHarvest) {
        GetComponent<Deletable>().Delete();
      }
    }
  }
}
