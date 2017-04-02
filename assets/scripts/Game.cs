using UnityEngine;

public class Game : MonoBehaviour {
  public static Game instance;
  public Selector selector;
  public CursorManager cursor;

  protected Game() {}

  void Awake() {
    if (Game.instance == null) {
      Game.instance = this;
    } else if (Game.instance != this) {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);

    selector = GetComponent<Selector>();
    cursor = GetComponent<CursorManager>();
  }

  public void Spawn(Object original, Vector3 position, Quaternion rotation) {
    Instantiate(original, position, rotation);
  }
}
