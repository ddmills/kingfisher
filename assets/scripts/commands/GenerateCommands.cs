using UnityEngine;
using UnityEditor;

namespace Entity.Command {

  public class CommandGenerator : Editor {
    [MenuItem("Assets/Create/Generate Commands")]

    public static void Generate() {
      ScriptableObject command = ScriptableObject.CreateInstance("Harvest");
      AssetDatabase.CreateAsset(command, "assets/commands/Harvest.asset");
      AssetDatabase.SaveAssets();
    }
  }
}
