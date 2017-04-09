using UnityEngine;

namespace Entity.Task {
  public abstract class Task {
    public abstract string rootVerb { get; }
    public abstract string presentVerb { get; }
    public abstract string pastVerb { get; }
    public GameObject entity;

    public Task() {}

    public virtual void Start(GameObject entity) {
      this.entity = entity;
    }

    public virtual void Update() {}

    public virtual void Cancel() {
      Debug.Log("task cancel");
    }

    public virtual void MarkComplete() {
      this.entity.GetComponent<TaskProcessor>().MarkComplete(this);
    }
  }
}
