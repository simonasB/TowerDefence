namespace TowerDefence.Visitor
{
    public interface IAcceptVisitorComponent
    {
        void Accept(IVisitor visitor);
    }
}
