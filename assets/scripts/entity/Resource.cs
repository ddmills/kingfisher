using UnityEngine;

public class Resource : MonoBehaviour {
  public void DoDisable() {
    // GetComponent<Selectable>().enabled = false;
    // GetComponent<BoxCollider>().enabled = false;
    // GetComponent<Entity.Command.Store>().enabled = false;
  }

  public void DoEnable() {
    // GetComponent<Selectable>().enabled = true;
    // GetComponent<BoxCollider>().enabled = true;
    // GetComponent<Entity.Command.Store>().enabled = true;
  }
}