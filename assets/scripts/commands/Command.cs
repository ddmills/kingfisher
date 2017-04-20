using UnityEngine;

namespace Entity.Command {

  public abstract class Command : MonoBehaviour {
    private bool _issued = false;
    public bool issued {
      get {
        return _issued;
      }
    }
    public bool visible = true;
    public bool issueOnStart = false;
    public abstract string label { get; }
    public abstract bool cancellable { get; }

    void Start() {
      if (issueOnStart) {
        Issue();
      }
    }

    public void Issue() {
      if (!issued) {
        _issued = true;
        OnIssue();
      }
    }

    public void Cancel() {
      if (issued) {
        _issued = false;
        OnCancel();
      }
    }

    public virtual void OnIssue() {}
    public virtual void OnCancel() {}
  }
}
