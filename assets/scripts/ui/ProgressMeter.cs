using UnityEngine;

public class ProgressMeter : MonoBehaviour {
  private float _progress = 0f;
  private float width;
  public bool hideOnZero = true;
  public bool hideOnFull = true;
  public CanvasGroup canvas;
  public float progress {
    get { return _progress; }
    set {
      _progress = value;
      OnChangeProgress();
    }
  }
  public RectTransform meter;

  void Start() {
    canvas = GetComponent<CanvasGroup>();
    width = GetComponent<RectTransform>().sizeDelta.x;
    OnChangeProgress();
  }

  void OnChangeProgress() {
    meter.sizeDelta = new Vector2(_progress * width, meter.sizeDelta.y);
    if (hideOnZero && _progress <= 0) {
      canvas.alpha = 0;
    } else if (hideOnFull && progress >= 1) {
      canvas.alpha = 0;
    } else {
      canvas.alpha = 1;
    }
  }
}
