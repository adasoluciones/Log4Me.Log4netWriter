using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.Log4netWrite.Entities
{
    public class RollingTag
    {
        [XmlAttribute]
        public string By { get; set; }

        [XmlAttribute]
        public string Value { get; set; }

        [XmlAttribute]
        public string Unit { get; set; }
    }
}
