using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Test_Minuto_Seguro.Model
{
    [XmlRoot("rss")]
    public class BlogMinutoXml
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
        
        public BlogMinutoXml()
        {
            Channel = new Channel();
        }

        private void ConvertListStringDateToDateTime()
        {
            Channel.LastBuildDateFormatted = Convert.ToDateTime(Channel.LastBuildDate);
            Channel.Item.ConvertAll(x => x.PubDateFormatted = Convert.ToDateTime(x.PubDate));
        }

        public void OrderByLastListFeeds()
        {
            ConvertListStringDateToDateTime();
            var c = new Channel
            {
                Item = Channel.Item.OrderByDescending(x => x.PubDateFormatted.Value).ToList()
            };
            Channel.Item = c.Item;
        }
    }

    public class Channel
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        
        [XmlElement(Namespace = "http://www.w3.org/2005/Atom", ElementName = "link")]
        public string AtomLink { get; set; }
        
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "lastBuildDate")]
        public string LastBuildDate { get; set; }

        public DateTime? LastBuildDateFormatted { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(Namespace = "http://purl.org/rss/1.0/modules/syndication/", ElementName = "updatePeriod")]
        public string SyUpdatePeriod { get; set; }

        [XmlElement(Namespace = "http://purl.org/rss/1.0/modules/syndication/", ElementName = "updateFrequency")]
        public int SyUpdateFrequency { get; set; }

        [XmlElement(ElementName = "generator")]
        public string Generator { get; set; }

        [XmlElement(ElementName = "item")]
        public List<ItemXml> Item = new List<ItemXml>();

    }

}
