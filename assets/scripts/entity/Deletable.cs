using UnityEngine;

public class Deletable : MonoBehaviour {
  public delegate void DeleteHandler();
  public event DeleteHandler OnDelete;
  public bool destroyOnDelete = true;
  public float destroyDelay = 0f;

  public void Delete() {
    if (OnDelete != null) {
      OnDelete();
    }
    if (destroyOnDelete) {
      Destroy(gameObject, destroyDelay);
    }
  }
}