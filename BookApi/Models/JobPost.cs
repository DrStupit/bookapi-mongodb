using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookApi.Models
{
    public class JobPost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        public Description Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }

    }

    public class Description
    {
        public string Overview { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public string Contact { get; set; }
    }
}
