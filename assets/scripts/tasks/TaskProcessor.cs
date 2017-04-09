using UnityEngine;

namespace Entity.Task {
  public class TaskProcessor : MonoBehaviour {
    public Task currentTask;
    private TaskQueue queue;

    void Start() {
      queue = Game.instance.taskQueue;
    }

    private void Update () {
      if (currentTask == null) {
        if (!queue.Empty()) {
          Task task = queue.GetTaskFor(this);
          BeginTask(task);
        }
      } else {
        currentTask.Update();
      }
    }

    private void BeginTask(Task task) {
      this.currentTask = task;
      Debug.Log(this.GetComponent<Selectable>().label + " is going to " + task.rootVerb);
      Debug.Log(this.GetComponent<Selectable>().label + " is currently " + task.presentVerb);
      this.currentTask.Start(this.gameObject);
    }

    public void MarkComplete(Task task) {
      this.currentTask = null;
      Debug.Log(this.GetComponent<Selectable>().label + " has " + task.pastVerb);
    }
  }
}
