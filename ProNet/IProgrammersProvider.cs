namespace ProNet
{
    public interface IProgrammersProvider
    {
        IRankCalculator GetAll(IXmlLoader xmlLoaded);
    }
}