using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test_Minuto_Seguro.Model
{
    [XmlRoot("item")]
    public class ItemXml
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "comments")]
        public string Comments { get; set; }

        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }

        public DateTime? PubDateFormatted { get; set; }

        [XmlElement(Namespace = "http://purl.org/dc/elements/1.1/", ElementName = "creator")]
        public string DcCreator { get; set; }

        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(Namespace = "http://purl.org/rss/1.0/modules/content/", ElementName = "encoded")]
        public string ContentEncoded { get; set; }

        [XmlElement(Namespace = "http://purl.org/rss/1.0/modules/slash/", ElementName = "comments")]
        public string SlashComments { get; set; }

        [XmlElement(Namespace = "http://wellformedweb.org/CommentAPI/", ElementName = "commentRss")]
        public string WfwCommentRss { get; set; }

        [XmlIgnore]
        public int TotalWord { get; set; }

        [XmlIgnore]
        public List<Words> CountMostRelevantWords = new List<Words>();

    }
}
