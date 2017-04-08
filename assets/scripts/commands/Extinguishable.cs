namespace Entity.Command {
  public class Extinguishable : Command {
    public override string label {
      get { return "Extinguish"; }
    }

    public override void Issue() {
      GetComponent<Fire>().flaggedForExtinction = true;
      visible = false;
    }
  }
}
