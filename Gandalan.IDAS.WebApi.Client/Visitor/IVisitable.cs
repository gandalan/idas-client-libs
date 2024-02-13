namespace Gandalan.IDAS.WebApi.Data.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
