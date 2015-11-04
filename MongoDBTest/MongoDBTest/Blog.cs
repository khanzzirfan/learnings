using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTest
{
    class Blog
    {
    }

    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }



    public class Post
    {
        [BsonRequired]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Title { get; set; }

        public string Author { get; set; }

        [BsonRequired]
        public DateTime CreatedAtUtc { get; set; }

        public string Content { get; set; }

        public List<string> Tags { get; set; }
        public List<Comment> Comments { get; set; }

    }


    public class Comment
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
