using System.Collections.Generic;
using UnityEngine;

namespace King.Actor.Task {
  public abstract class Task {
    public abstract string rootVerb { get; }
    public abstract string presentVerb { get; }
    public abstract string pastVerb { get; }

    public delegate void CompleteHandler();
    public event CompleteHandler OnCompleteE;

    public List<Worker> workers = new List<Worker>();
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

    public void AddWorker(Worker worker) {
      workers.Add(worker);
      OnAddWorker(worker);
    }

    public void RemoveWorker(Worker worker) {
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
        if (OnCompleteE != null) {
          OnCompleteE();
        }
        queue.Completed(this);
      }
    }

    public virtual void Process(Worker worker) {}
    public virtual void OnAddWorker(Worker worker) {}
    public virtual void OnRemoveWorker(Worker worker) {}
    public virtual void OnCancel() {}
    public virtual void OnComplete() {}
    public virtual float Weight(Worker worker) {
      return 1f;
    }
    public abstract bool CanBeWorkedBy(Worker worker);
  }
}
