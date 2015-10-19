using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDBTest
{
    public class Orders
    {
        public ObjectId Id { get; set; }
        public decimal OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
