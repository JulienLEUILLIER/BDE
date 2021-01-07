namespace TP8
{
    public interface IVisitable
    {
        void Accept(IVisitor v);
    }
}