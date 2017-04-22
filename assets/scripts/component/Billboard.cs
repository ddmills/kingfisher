using UnityEngine;

namespace King.Component {
  public class Billboard : MonoBehaviour {
    void Update() {
      transform.LookAt(Camera.main.transform);
    }
  }
}
