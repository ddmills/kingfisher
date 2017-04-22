using UnityEngine;
using System.Collections.Generic;

namespace King.Actor.Task {
  public class TaskQueue : MonoBehaviour {
    private List<Task> tasks = new List<Task>();

    public bool Empty() {
      return tasks.Count <= 0;
    }

    private bool TaskCanBeWorkedBy(Task task, Worker processor) {
      return processor.task == task || (task.CanBeWorkedBy(processor) && task.maxWorkers > task.workers.Count);
    }

    public Task HighestPriorityTask(Worker processor) {
      Task highestTask = null;
      float highestPriority = 0f;

      foreach (Task task in tasks) {
        if (TaskCanBeWorkedBy(task, processor)) {
          float weight = Weight(processor, task);
          if (weight > highestPriority) {
            highestPriority = weight;
            highestTask = task;
          }
        }
      }

      return highestTask;
    }

    public void AssignTask(Worker processor) {
      Task task = HighestPriorityTask(processor);

      if (task != null && task.Equals(processor.task)) {
        return;
      }

      if (task == null) {
        task = processor.GetDefaultTask(this);
      }

      if (processor.task != null) {
        processor.task.RemoveWorker(processor);
        processor.StopTask();
      }

      processor.task = task;
      processor.BeginTask(task);
      task.AddWorker(processor);
    }

    public bool ShouldContinueWithTask(Worker processor) {
      return true;
    }

    private float Weight(Worker processor, Task task) {
      return task.Weight(processor) * processor.Weight(task);
    }

    public void Push(Task task) {
      tasks.Add(task);
    }

    public void Cancelled(Task task) {
      tasks.Remove(task);
      task.workers.ForEach(worker => {
        task.RemoveWorker(worker);
        worker.OnTaskCancelled(task);
      });
    }

    public void Completed(Task task) {
      tasks.Remove(task);
      task.workers.ForEach(worker => {
        task.RemoveWorker(worker);
        worker.OnTaskCompleted(task);
      });
    }
  }
}
