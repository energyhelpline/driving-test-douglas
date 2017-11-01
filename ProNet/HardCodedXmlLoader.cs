using System.Xml.Linq;

namespace ProNet
{
    public class HardCodedXmlLoader : IXmlLoader
    {
        public XElement Load()
        {
            var xml = XElement.Parse(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
            <Network>
                <Programmer name='Nick'></Programmer>
                <Programmer name='Bill'></Programmer>
                <Programmer name='Dave'></Programmer>
                <Programmer name='Ed'>
                    <Recommendations>
                        <Recommendation>Liz</Recommendation>
                        <Recommendation>Rick</Recommendation>
                        <Recommendation>Bill</Recommendation>
                    </Recommendations>
                </Programmer>
                <Programmer name='Liz'></Programmer>
                <Programmer name='Rick'></Programmer>
            </Network>");
            return xml;
        }
    }
}