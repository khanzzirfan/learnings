using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IMongoClient client;
            IMongoDatabase database;
            // const string connectionString = "mongodb://myUserName:MyPassword@linus.mongohq.com:myPortNumber/";
            const string connectionString = "mongodb://localhost/?replicaSet=myReplSet&readPreference=primary";
            // const string connectionString = "mongodb://localhost";

            client = new MongoClient(connectionString);
            database = client.GetDatabase("test");

            QueryAllDocuments(database);

            //QueryByModel(database);
            
            InsertOrders(database);

            UpdateOrders(database);

            DeleteOrders(database);
            Console.ReadLine();

        }


        public static async void DeleteOrders(IMongoDatabase db)
        {
            var collections = db.GetCollection<Orders>("orders");
            var filter = Builders<Orders>.Filter.Eq("Name", "Irfan");
           
            //Delete One Document;
            var result = await collections.DeleteOneAsync(filter);
            Console.WriteLine("Delete Count {0}", result.DeletedCount);

            //Delete Many Documents;
            result = await collections.DeleteManyAsync(filter);
            Console.WriteLine("Delete Many Count {0}", result.DeletedCount);

        }

        public static async void UpdateOrders(IMongoDatabase db)
        {
            var collections = db.GetCollection<Orders>("orders");
            //var filter = new FilterDefinitionBuilder<Orders>().Eq("Name", "Irfan");
            var filter = Builders<Orders>.Filter.Eq("Name", "Irfan");
            var update = Builders<Orders>.Update
                                         .Set(c => c.Date, DateTime.Now.AddDays(1))
                                         .Set(c => c.TotalAmount, 25.0m);

            var result = await collections.UpdateOneAsync(filter, update);
            //var result = await collections.UpdateManyAsync(filter, update);
            var res = result;

            var searchfilter = new FilterDefinitionBuilder<Orders>().Eq("Name", "Irfan");
            var searchresult = await collections.Find(searchfilter).ToListAsync();
            foreach (var r in searchresult)
            {
                Console.WriteLine("OrderId {0}, OrderTotal {1}, OrderDate {2}", r.OrderId, r.TotalAmount, r.Date);
            }


            var result2 = await collections.UpdateManyAsync(filter, update);
            res = result2;

            searchfilter = new FilterDefinitionBuilder<Orders>().Eq("Name", "Irfan");
            searchresult = await collections.Find(searchfilter).ToListAsync();
            foreach (var r in searchresult)
            {
                Console.WriteLine("Name: {3} OrderId {0}, OrderTotal {1}, OrderDate {2}", r.OrderId, r.TotalAmount, r.Date, r.Name);
            }

        }

        public static async void InsertOrders(IMongoDatabase db)
        {
            var collections = db.GetCollection<Orders>("orders");
            var data = new Orders()
            {
                OrderId = 1,
                Date = DateTime.Now,
                Name = "Irfan",
                TotalAmount = 10.0m,
            };

            var datalist = new List<Orders>()
            {
                new Orders(){OrderId =  1, Date = DateTime.Now, Name = "Irfan",TotalAmount = 10.0m, }, 
                new Orders(){OrderId =  1, Date = DateTime.Now, Name = "Klayan",TotalAmount = 10.0m, }, 
                new Orders(){OrderId =  1, Date = DateTime.Now, Name = "Khan",TotalAmount = 10.0m, }, 
            };

            //Insert Single Document
            await collections.InsertOneAsync(data);
            Console.WriteLine("Insert Count 1");
            //Insert Multiple Documents;
            await collections.InsertManyAsync(datalist);
            Console.WriteLine("Insert Count Many");

            var filter = new FilterDefinitionBuilder<Orders>().Eq("Name", "Irfan");
            var result = await collections.Find(filter).ToListAsync();

            foreach (var r in result)
            {
                Console.WriteLine("OrderId {0}, OrderTotal {1}, OrderDate {2}", r.OrderId, r.TotalAmount, r.Date);
            }
        }

        public static async void QueryAllDocuments(IMongoDatabase db)
        {
            var collections = db.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            var count = 0;
            using (var cursor = await collections.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        var doc = document;
                        count ++;
                    }
                }
            }
            Console.WriteLine("Total Count {0}", count);
        }//Eof QueryAllDocuments


        public static async void QueryByModel(IMongoDatabase db)
        {
            string key = "borough";
            string value = "Manhattan";
            var collection = db.GetCollection<Resturant>("restaurants");
            var filter = new FilterDefinitionBuilder<Resturant>().Eq(key, value);
            var result = await collection.Find(filter).ToListAsync();
            var count = result.Count;

            foreach (var resturant in result)
            {
                var r = resturant;

            }
            Console.WriteLine("Total For {0} is {1} ", key,count);
        }


    }
}
