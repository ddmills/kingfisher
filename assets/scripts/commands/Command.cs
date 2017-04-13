using UnityEngine;

namespace Entity.Command {

  public abstract class Command : MonoBehaviour {
    public bool issued = false;
    public bool visible = true;
    public abstract string label { get; }
    public abstract bool cancellable { get; }

    void Start() {
      if (issued) {
        this.Issue();
      }
    }

    public void Issue() {
      issued = true;
      OnIssue();
    }

    public void Cancel() {
      issued = false;
      OnCancel();
    }

    public virtual void OnIssue() {}
    public virtual void OnCancel() {}
  }
}
