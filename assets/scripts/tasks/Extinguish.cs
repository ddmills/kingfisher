using Entity.Behavior;

namespace Entity.Task {
  public class Extinguish : Work {
    public override string rootVerb { get { return "extinguish fire"; } }
    public override string presentVerb { get { return "extinguishing fire"; } }
    public override string pastVerb { get { return "extinguished fire"; } }

    public Extinguish(Extinguishable extinguishable) : base(extinguishable) {}
  }
}
