using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour {

  public float panSpeed = 4f;
  public bool invertPan = false;

  private float previousMouseX = 0.0f;
  private float previousMouseY = 0.0f;

  private Selector selector;

  void Start() {
    this.selector = this.GetComponent<Selector>();
  }

  void Update () {
    if (Input.GetMouseButtonDown(2)) {
      this.previousMouseX = Input.mousePosition.x;
      this.previousMouseY = Input.mousePosition.y;
    }

    if (Input.GetMouseButton(2)) {
      this.Pan();
    }

    if (Input.GetMouseButtonDown(1)) {
      if (this.selector.selected) {
        this.TryPlace(this.selector.selected.gameObject);
      }
    }
  }

  private void Pan() {
    float mouseOffsetX = Input.mousePosition.x - this.previousMouseX;
    float mouseOffsetY = Input.mousePosition.y - this.previousMouseY;

    mouseOffsetX *= invertPan ? -1 : 1;
    mouseOffsetY *= invertPan ? -1 : 1;

    transform.Translate(Vector3.right * Time.deltaTime * panSpeed * mouseOffsetX, Space.World);
    transform.Translate(Vector3.forward * Time.deltaTime * panSpeed * mouseOffsetY, Space.World);

    this.previousMouseX = Input.mousePosition.x;
    this.previousMouseY = Input.mousePosition.y;
  }

  private void TryPlace(GameObject thing) {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100)) {
      Instantiate(thing, hit.point, Quaternion.identity);
    }
  }
}
