using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.Log4netWrite.Entities
{
    public class OutputTag
    {
        [XmlAttribute]
        public string Path { get; set; }

        [XmlAttribute]
        public string FileNameFormat { get; set; }

        [XmlAttribute]
        public string DateFormat { get; set; }
    }
}