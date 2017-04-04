using UnityEngine;

public abstract class Task {
  public abstract string rootVerb { get; }
  public abstract string presentVerb { get; }
  public abstract string pastVerb { get; }
  public GameObject entity;

  public Task(GameObject entity) {
    this.entity = entity;
  }

  public virtual void Start() {}

  public virtual void Update() {}

  public virtual void Cancel() {}

  public virtual void MarkComplete() {
    this.entity.GetComponent<TaskProcessor>().MarkComplete(this);
  }
}
