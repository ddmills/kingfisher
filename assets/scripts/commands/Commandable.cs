using System.Collections.Generic;
using UnityEngine;

namespace Entity.Command {
  public class Commandable : MonoBehaviour {

    public List<Command> commands;

    void Start () {
      // if (this.commands.Count > 0) {
      //   this.commands[0].Execute(this.gameObject);
      // }
    }

    void Update () {

    }
  }
}
