using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Fit24Data
{
    public enum ContentType { standart, stringContent, pictureContent, newPage };
    public class Content
    {
        public string ContentTitel = "ContentTitel";
        public ContentType ContentType = ContentType.standart;
        protected object content = null;
        public object ContentObject
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        public List<Content> Items = new List<Content>();

        public static Content Load(string filePath)
        {
            XmlSerializer x = new XmlSerializer(typeof(Content));
            FileStream fs = new FileStream(filePath, FileMode.Open);
            Content res = (Content)x.Deserialize(fs);
            fs.Close();
            return res;
        }

        public static void Save(string filePath, Content content)
        {
            XmlSerializer x = new XmlSerializer(typeof(Content));
            TextWriter writer = new StreamWriter(filePath);
            x.Serialize(writer, content);
            writer.Close();
        }
    }
    [System.Xml.Serialization.XmlInclude(typeof(ContentString))]
    public class ContentString : Content
    {
        public ContentString()
        {
            content = "";
            ContentType = ContentType.stringContent;
        }
    }
    [System.Xml.Serialization.XmlInclude(typeof(ContentNewPage))]
    public class ContentNewPage : Content
    {
        public ContentNewPage()
        {
            content = "";
            ContentType = ContentType.newPage;
        }
    }
}
