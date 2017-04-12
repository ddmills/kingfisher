using UnityEngine;

namespace Entity.Task {
  public class TaskProcessor : MonoBehaviour {
    private TaskQueue queue;
    public Task task;

    void Start() {
      queue = Game.instance.taskQueue;
    }

    private void Update () {
      queue.AssignTask(this);
      if (task != null) {
        task.Process(this);
      }
    }

    public void BeginTask(Task task) {
      Debug.Log(this.GetComponent<Selectable>().label + " is going to " + task.rootVerb);
      Debug.Log(this.GetComponent<Selectable>().label + " is currently " + task.presentVerb);
    }

    public void StopTask() {
      Debug.Log(this.GetComponent<Selectable>().label + " stopped " + task.presentVerb);
    }

    public void OnTaskCompleted(Task task) {
      Debug.Log(this.GetComponent<Selectable>().label + " has " + task.pastVerb);
    }

    public void OnTaskCancelled(Task task) {
      Debug.Log(this.GetComponent<Selectable>().label + " stopped " + task.presentVerb + " because it was cancelled");
    }

    public Task GetDefaultTask(TaskQueue queue) {
      return new Wander(queue);
    }

    public float TaskPreference(Task task) {
      if (this.task != null && this.task.Equals(task)) {
        return 2;
      } else {
        return 1;
      }
    }
  }
}
