namespace ProNet
{
    public class ProgrammerFactory : IProgrammerFactory
    {
        public IProgrammer BuildProgrammer(string name)
        {
            return new Programmer(name);
        }
    }
}