using System;
using System.Collections.Generic;

namespace Fit24Data
{

    public class Content
    {
        public enum ContentType { stringContent, pictureContent };
        public virtual class Content
        {
            public string ContentTitel = "ContentTitel";
            protected var content = null;
            public object Content
            {
                get
                {
                    return content;
                }
            }
            public List<Content> Items = new List<Content>();
        }
        public class ContentString : Content
        {
            public ContentString()
            {
                content = "";
            }
        }
    }
}