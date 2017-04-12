using UnityEngine;
using Entity.Behavior;

namespace Entity.Task {
  public class Wander : Task {
    public override string rootVerb { get { return "wander"; } }
    public override string presentVerb { get { return "wandering"; } }
    public override string pastVerb { get { return "wandered"; } }

    public Wander(TaskQueue queue) : base(queue) {
      manualPriority = .1f;
    }

    public override void OnAddWorker(TaskProcessor worker) {
      Debug.Log("Start wanderiong");
      worker.GetComponent<Wanderable>().Wander();
    }

    public override void OnRemoveWorker(TaskProcessor worker) {
      Debug.Log("Stooop wanderiong");
      worker.GetComponent<Wanderable>().Stop();
    }

    public override bool CanBeWorkedBy(TaskProcessor worker) {
      return worker.GetComponent<Wanderable>() != null;
    }
  }
}
