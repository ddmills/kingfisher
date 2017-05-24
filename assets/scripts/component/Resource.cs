using UnityEngine;

namespace King.Component {
  [CreateAssetMenu(fileName = "Resource", menuName = "Resource", order = 2)]
  public class Resource : ScriptableObject {
    public string singularName;
    public string pluralname;
    public GameObject gameObject;
    public bool stackable;
    public float weight;
    public int maxStackSize;

    public GameObject Manifest(Vector3 position) {
      return (GameObject) Game.instance.Spawn(gameObject, position, Quaternion.identity);
    }
  }
}
