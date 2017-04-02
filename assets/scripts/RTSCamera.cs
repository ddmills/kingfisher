using UnityEngine;

public class RTSCamera : MonoBehaviour {

  public float rotationSpeed = .15f;
  public bool invertRotation = true;
  public float zoomSpeed = 2.5f;
  public float panSpeed = 4f;
  public bool invertPan = false;

  public float ROTATION_CLAMP_MIN = 25f;
  public float ROTATION_CLAMP_MAX = 70f;
  public float ZOOM_CLAMP_MIN = -40f;
  public float ZOOM_CLAMP_MAX = -8f;
  private float previousMouseX = 0f;
  private float previousMouseY = 0f;

  private GameObject cam;

  void Start() {
    this.cam = this.transform.FindChild("camera").gameObject;
  }

  void Update () {
    if (Input.GetMouseButton(2) && Input.GetKey(KeyCode.LeftControl)) {
      this.Rotate();
    } else if (Input.GetMouseButton(2)) {
      this.Pan();
    }

    if (Input.GetAxis("Mouse ScrollWheel") < 0) {
      this.ZoomOut();
    }

    if (Input.GetAxis("Mouse ScrollWheel") > 0) {
      this.ZoomIn();
    }

    this.previousMouseX = Input.mousePosition.x;
    this.previousMouseY = Input.mousePosition.y;
  }

  private void ZoomOut() {
    float z = Mathf.Clamp(
      this.cam.transform.localPosition.z - this.zoomSpeed,
      this.ZOOM_CLAMP_MIN,
      this.ZOOM_CLAMP_MAX
    );

    this.cam.transform.localPosition = new Vector3(0, 0, z);
  }

  private void ZoomIn() {
    float z = Mathf.Clamp(
      this.cam.transform.localPosition.z + this.zoomSpeed,
      this.ZOOM_CLAMP_MIN,
      this.ZOOM_CLAMP_MAX
    );

    this.cam.transform.localPosition = new Vector3(0, 0, z);
  }

  private void Rotate() {
    float mouseOffsetX = Input.mousePosition.x - this.previousMouseX;
    float mouseOffsetY = Input.mousePosition.y - this.previousMouseY;

    mouseOffsetX *= invertRotation ? -1 : 1;
    mouseOffsetY *= invertRotation ? 1 : -1;

    float rotationX = this.transform.localEulerAngles.x - mouseOffsetY * this.rotationSpeed;
    float rotationY = this.transform.eulerAngles.y - mouseOffsetX * this.rotationSpeed;

    this.transform.localEulerAngles = new Vector3(
      Mathf.Clamp(rotationX, this.ROTATION_CLAMP_MIN, this.ROTATION_CLAMP_MAX),
      this.transform.localEulerAngles.y,
      this.transform.localEulerAngles.z
    );

    this.transform.eulerAngles = new Vector3(
      this.transform.eulerAngles.x,
      rotationY,
      this.transform.eulerAngles.z
    );
  }

  private void Pan() {
    float mouseOffsetX = Input.mousePosition.x - this.previousMouseX;
    float mouseOffsetY = Input.mousePosition.y - this.previousMouseY;

    mouseOffsetX *= invertPan ? -1 : 1;
    mouseOffsetY *= invertPan ? -1 : 1;

    Vector3 direction = new Vector3(
      this.transform.forward.x,
      0,
      this.transform.forward.z
    );

    direction.Normalize();

    Vector3 forward = direction * Time.deltaTime * panSpeed * mouseOffsetY;
    Vector3 right = Vector3.right * Time.deltaTime * panSpeed * mouseOffsetX;

    transform.Translate(right, Space.Self);
    transform.Translate(forward, Space.World);

    this.previousMouseX = Input.mousePosition.x;
    this.previousMouseY = Input.mousePosition.y;
  }
}
