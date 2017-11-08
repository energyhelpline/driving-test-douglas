namespace ProNet
{
    public interface IProgrammerFactory
    {
        IProgrammer BuildProgrammer(string name);
    }
}