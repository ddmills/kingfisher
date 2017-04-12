using System.Collections.Generic;
using UnityEngine;

namespace Entity.Task {
  public abstract class Task {
    public abstract string rootVerb { get; }
    public abstract string presentVerb { get; }
    public abstract string pastVerb { get; }
    public List<TaskProcessor> workers = new List<TaskProcessor>();
    private float createdAt;
    private bool completed = false;
    public bool isAssigned {
      get { return workers.Count > 0; }
    }
    public int maxWorkers = 1;
    public float age {
      get { return Time.realtimeSinceStartup - createdAt; }
    }
    protected TaskQueue queue;

    public Task(TaskQueue queue) {
      this.queue = queue;
      createdAt = Time.realtimeSinceStartup;
      this.queue.Push(this);
    }

    public void AddWorker(TaskProcessor worker) {
      workers.Add(worker);
      OnAddWorker(worker);
    }

    public void RemoveWorker(TaskProcessor worker) {
      workers.Remove(worker);
      OnRemoveWorker(worker);
    }

    public void Cancel() {
      OnCancel();
      queue.Cancelled(this);
    }

    public void Complete() {
      if (!completed) {
        completed = true;
        OnComplete();
        queue.Completed(this);
      }
    }

    public virtual void Process(TaskProcessor worker) {}
    public virtual void OnAddWorker(TaskProcessor worker) {}
    public virtual void OnRemoveWorker(TaskProcessor worker) {}
    public virtual void OnCancel() {}
    public virtual void OnComplete() {}
    public virtual float Weight(TaskProcessor worker) {
      return 1f;
    }
    public abstract bool CanBeWorkedBy(TaskProcessor worker);
  }
}
