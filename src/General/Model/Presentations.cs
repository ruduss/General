using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Model
{
    public class Presentations
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("presentation_title")]
        public string PresentationTitle { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }
        [BsonElement("pages")]
        public List<Pages> PresentationPages { get; set; }

    }

    public class Pages
    {
        [BsonElement("page_title")]
        public string PageTitle { get; set; }
        
        [BsonElement("body")]
        public string Body { get; set; }

        [BsonElement("order")]
        public int order { get; set; }
    }
}
