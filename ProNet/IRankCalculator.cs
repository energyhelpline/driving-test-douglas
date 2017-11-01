namespace ProNet
{
    public interface IRankCalculator
    {
        void Calculate();
        decimal RankFor(string name);
    }
}