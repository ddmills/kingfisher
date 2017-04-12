using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public class Plant : Work {
    public override string rootVerb { get { return "plant"; } }
    public override string presentVerb { get { return "planting"; } }
    public override string pastVerb { get { return "planted"; } }

    public Plant(TaskQueue queue, Plantable plantable) : base(queue, plantable) {
      Debug.Log("Plant stuff");
      Debug.Log(plantable);
    }

    public override bool CanBeWorkedBy(TaskProcessor worker) {
      return worker.GetComponent<MoveTo>() != null;
    }

    public override void OnCancel() {
      workable.Reset();
    }
  }
}
