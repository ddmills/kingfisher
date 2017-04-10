using UnityEngine;
using System.Collections.Generic;

namespace Entity.Task {
  public class TaskQueue : MonoBehaviour {
    private List<Task> tasks = new List<Task>();

    public bool Empty() {
      return tasks.Count <= 0;
    }

    public Task GetTaskFor(TaskProcessor processor) {
      Task t = tasks[0];
      tasks.RemoveAt(0);
      return t;
    }

    public void Push(Task task) {
      tasks.Add(task);
    }

    public void Cancel(Task task) {
      tasks.Remove(task);
    }
  }
}