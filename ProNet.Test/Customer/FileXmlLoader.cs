using System.IO;
using System.Xml.Linq;

namespace ProNet.Test.Customer
{
    public class FileXmlLoader : IXmlLoader
    {
        private readonly string _filename;

        public FileXmlLoader(string filename)
        {
            _filename = filename;
        }

        public XElement Load()
        {
            return XElement.Parse(File.ReadAllText(_filename));
        }
    }
}