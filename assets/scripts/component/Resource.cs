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

    public ResourceManifestation Manifest(Vector3 position, int quantity = 1) {
      GameObject instance = (GameObject) Game.instance.Spawn(gameObject, position, Quaternion.identity);
      ResourceManifestation manifestation = instance.GetComponent<ResourceManifestation>();
      manifestation.quantity = quantity;
      return manifestation;
    }
  }
}
