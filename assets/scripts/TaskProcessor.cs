using System.Collections.Generic;
using UnityEngine;

public class TaskProcessor : MonoBehaviour {

  public List<Ability> abilities;
  public Task currentTask;

  void Start () {
    MoveTask move = new MoveTask(this.gameObject);
    move.SetGoal(new Vector3(5, 0, -5));
    this.BeginTask(move);
  }

  public bool CanPerform(Task task) {
    return false;
  }

  private void Update () {
    if (this.currentTask != null) {
      this.currentTask.Update();
    }
  }

  private void BeginTask(Task task) {
    this.currentTask = task;
    this.currentTask.Start();
    Debug.Log("Going to " + task.rootVerb);
    Debug.Log("Currently " + task.presentVerb);
  }

  private void CancelTask(Task task) {
    this.currentTask.Cancel();
    this.currentTask = null;
  }

  public void MarkComplete(Task task) {
    this.currentTask = null;
    Debug.Log("Was " + task.pastVerb);
  }
}
