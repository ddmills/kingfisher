﻿using UnityEngine;
using Entity.Task;

public class Game : MonoBehaviour {
  public static Game instance;
  public Selector selector;
  public CursorManager cursor;
  public TaskQueue taskQueue;

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
    taskQueue = GetComponent<TaskQueue>();
  }

  public Object Spawn(Object original, Vector3 position, Quaternion rotation) {
    return Instantiate(original, position, rotation);
  }
}
