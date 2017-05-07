using UnityEngine;

namespace King.Actor.Command {

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
    public delegate void StateChangeHandler();
    public event StateChangeHandler OnStateChangeE;

    void Start() {
      if (issueOnStart) {
        Issue();
      }
    }

    public void Issue() {
      if (!issued) {
        _issued = true;
        OnIssue();
        if (OnStateChangeE != null) {
          OnStateChangeE();
        }
      }
    }

    public void Cancel() {
      if (issued) {
        _issued = false;
        OnCancel();
        if (OnStateChangeE != null) {
          OnStateChangeE();
        }
      }
    }

    public void Enable() {
      enabled = true;
      if (OnStateChangeE != null) {
        OnStateChangeE();
      }
    }

    public void Disable() {
      enabled = false;
      if (OnStateChangeE != null) {
        OnStateChangeE();
      }
    }

    public virtual void OnIssue() {}
    public virtual void OnCancel() {}
  }
}
