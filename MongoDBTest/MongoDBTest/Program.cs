using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
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

            
            /**
            QueryAllDocuments(database);
            //QueryByModel(database);
            InsertOrders(database);
            UpdateOrders(database);
            DeleteOrders(database);
            ****/

            //   QueryAggregation(database, "restaurants");
            //   QueryGroupBy(database, "restaurants");
           
           //Home Work Json 2.1
           //InsertGrades(database);
          //  QueryGroupByGrades(database);

            //Home Work Json 3.1
            InsertStudentScore(database);
            
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

        public static async void InsertGrades(IMongoDatabase db)
        {
            string jsonPath = @"C:\Codec\MongoDB\Uni\week_2_crud.bf5486e303a0\homework_2_1\grades.json";

            try
            {
                await db.DropCollectionAsync("grades");
                var collection = db.GetCollection<Grades>("grades");
                
                using (var streamReader = new StreamReader(jsonPath))
                {
                 

                    string line;
                    while ((line = await streamReader.ReadLineAsync()) != null)
                    {
                        using (var jsonReader = new JsonReader(line))
                        {
                            var context = BsonDeserializationContext.CreateRoot(jsonReader);
                            var document = collection.DocumentSerializer.Deserialize(context);
                            await collection.InsertOneAsync(document);
                        }
                    }
                }
                Console.WriteLine("Successfully Uploaded Grades");
                Console.WriteLine("Querying all documents");
               
                await QueryAllDocuments(db, "grades");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception \n\n");
                Console.WriteLine(ex.Message);
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

        public static async Task<int> QueryAllDocuments(IMongoDatabase db, string collectionName="restaurants")
        {
            var collections = db.GetCollection<BsonDocument>(collectionName);
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

            return 1;
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

        public static async Task<int> QueryAggregation(IMongoDatabase db, string collectionName = "restaurants")
        {
           var v =  await QueryAllDocuments(db, collectionName);

           var collection = db.GetCollection<BsonDocument>(collectionName);

            //Aggregation Filter for Greater Than
            var filter = Builders<BsonDocument>.Filter.Gt("grades.score", 30);
            var result = await collection.Find(filter).ToListAsync();
            var count = result.Count;
            Console.WriteLine("Total For {0} is {1} ", "grades with score > 30: ", count);

            //Aggregation Filter for less Than
            filter = Builders<BsonDocument>.Filter.Lt("grades.score", 10);
            result = await collection.Find(filter).ToListAsync();
            count = result.Count;
            Console.WriteLine("Total For {0} is {1} ", "grades with score < 10: ", count);

            //Aggregation Filter for Logical And
            var builder = Builders<BsonDocument>.Filter;
            filter = builder.Eq("cuisine", "Italian") & builder.Eq("address.zipcode", "10075");
            result = await collection.Find(filter).ToListAsync();
            count = result.Count;
            Console.WriteLine("Total For {0} is {1} ", "cuisine & zip code 10075", count);

            //Aggregation Filter for Logical OR
            builder = Builders<BsonDocument>.Filter;
            filter = builder.Eq("cuisine", "Italian") | builder.Eq("address.zipcode", "10075");
            result = await collection.Find(filter).ToListAsync();
            count = result.Count;
            Console.WriteLine("Total For {0} is {1} ", "cuisine || zip code 10075", count);

            //Aggregation Filter for Logical Sort By
            filter = new BsonDocument();
            var sort = Builders<BsonDocument>.Sort.Ascending("borough").Ascending("address.zipcode");
            result = await collection.Find(filter).Sort(sort).ToListAsync();
            count = result.Count;
            Console.WriteLine("Total For {0} is {1} ", "Sort By", count);


            return 1;
        }



        public static async Task<int> QueryGroupBy(IMongoDatabase db, string collectionName = "restaurants")
        {
            var v = await QueryAllDocuments(db, collectionName);

            var collection = db.GetCollection<BsonDocument>(collectionName);

            var aggregate = collection.Aggregate().Group(new BsonDocument { { "_id", "$borough" }, { "count", new BsonDocument("$sum", 1) } });
            var result = await aggregate.ToListAsync();
            var count = result.Count;
            foreach (var resturant in result)
            {
                var r = resturant;

            }

            Console.WriteLine("Total For {0} is {1} ", "Group By", count);

            aggregate = collection.Aggregate()
                .Match(new BsonDocument { { "borough", "Queens" }, { "cuisine", "Brazilian" } })
                .Group(new BsonDocument { { "_id", "$address.zipcode" }, { "count", new BsonDocument("$sum", 1) } });
            var results = await aggregate.ToListAsync();
            foreach (var resturant in results)
            {
                var r = resturant;

            }
            

            //Now WOrk WIth Grades
            //await QueryGroupByGrades(db, "grades");
            await RemoveGradesByType(db, "grades");
            return 1;
        }



        public static async Task<int> QueryGroupByGrades(IMongoDatabase db, string collectionName = "grades")
        {

            var v = await QueryAllDocuments(db, collectionName);
            var collection = db.GetCollection<BsonDocument>(collectionName);
            var gradeCollection = db.GetCollection<Grades>(collectionName);
           
            var filter = Builders<BsonDocument>.Filter.Gte("score", 65);
            var aggregate = collection.Aggregate()
                                  .Match(filter)
                                  .Group(new BsonDocument
                                  {
                                      {
                                          "_id", new BsonDocument
                                          {
                                              { "studentID", "$student_id" },
                                              { "scores", "$score" },
                                          }
                                      },
                                      { "count", new BsonDocument("$sum", 1) }
                                  });
            var sort = Builders<BsonDocument>.Sort.Ascending("_id.scores");
            var result = await aggregate.Sort(sort).ToListAsync();

            
            foreach (var resturant in result)
            {
                var r = resturant;

            }

            var getList = gradeCollection.AsQueryable().Where(p => p.score >= 65).ToList();
            var sortedList = getList.OrderBy(c => c.score).ToList().FirstOrDefault();


            //  //Aggregation Filter for Greater Than
            //var myfilter = Builders<Grades>.Filter.Gte("score", 65);
            //var getMyFilterasync = await gradeCollection.FindAsync(myfilter);
            //var myresult = getMyFilterasync.

           
            // Console.WriteLine("Total For {0} is {1} ", "Group By", count);
            return 1;
        }


        public static async Task<int> RemoveGradesByType(IMongoDatabase db, string collectionName = "grades")
        {
            int x = 3;
            var gradedocument = db.GetCollection<Grades>(collectionName);
            var gradeCollection = gradedocument.AsQueryable().ToList();
            var count = gradeCollection.Count();
            Console.WriteLine("Total Records {0}",  count);

            var lowScoreHomeGrade = gradeCollection.Where(c => c.type == "homework").ToList();

            var lowScoreMinList = lowScoreHomeGrade.GroupBy(c => c.student_id)
                                                   .Select(g => new
                                                   {
                                                       key = g.Key,
                                                       LowScoreHome = g.Min(m=> m.score),
                                                   }).ToList();

            var newGradesCollection = gradeCollection;
            foreach (var item in lowScoreMinList)
            {
                var removeId = gradeCollection.Single(c => c.student_id == item.key && c.score == item.LowScoreHome);
                if (removeId != null)
                    newGradesCollection.Remove(removeId);
            }

            //Now Find 101st best Grade Across all grades
            var grade101 = newGradesCollection.OrderBy(c => c.score).Skip(100).Take(1).Single();
            var gradeDesc = newGradesCollection.OrderByDescending(c => c.score).Skip(100).Take(1).Single();
            var gradebyStudent = newGradesCollection.OrderBy(c => c.student_id).ThenBy(c => c.score).Take(5).ToList();


            //var aggregate = newGradesCollection.Aggregate().Group(new BsonDocument { { "_id", "$borough" }, { "count", new BsonDocument("$sum", 1) } });
            //var aggregate = newGradesCollection.Aggregate()
            //                      .Group(new BsonDocument
            //                      {
            //                          {"_id","$student_id"},
            //                          { "average", new BsonDocument("$avg", "$score") }
            //                      });

            var linqAgg = newGradesCollection.GroupBy(c => c.student_id)
                                             .Select(m => new
                                             {
                                                 key = m.Key,
                                                 values = new Grades()
                                                 {
                                                     _id = m.Max(d=> d._id),
                                                     student_id = m.Max(d=> d.student_id),
                                                     score = m.Average(d=> d.score),
                                                     type = m.Max(d=> d.type)
                                                 }
                                             }).ToList();

            var newAggCollection = linqAgg.Select(c => new Grades()
            {
                _id = c.values._id,
                score = c.values.score,
                student_id = c.values.student_id,
                type = c.values.type
                
            }).ToList();


            var sortCollection = newAggCollection.OrderByDescending(c => c.score).ToList();

            var takeoneCollection = sortCollection.Take(1).Single();

            foreach (var item in linqAgg)
            {
                var t1 = item;
            }

            //var sort = Builders<BsonDocument>.Sort.Ascending("average");
            //var result = await aggregate.Sort(sort).ToListAsync();

            return 1;
        }


        #region week3_Exam


        public static async void InsertStudentScore(IMongoDatabase db)
        {
            var jsonPath = @"C:\Codec\MongoDB\Uni\homework_3_1\students.json";
            var collectionName = "studentscore";
            try
            {
                await db.DropCollectionAsync(collectionName);
                var collection = db.GetCollection<StudentScore>(collectionName);

                using (var streamReader = new StreamReader(jsonPath))
                {
                    string line;
                    while ((line = await streamReader.ReadLineAsync()) != null)
                    {
                        using (var jsonReader = new JsonReader(line))
                        {
                            var context = BsonDeserializationContext.CreateRoot(jsonReader);
                            var document = collection.DocumentSerializer.Deserialize(context);
                            await collection.InsertOneAsync(document);
                        }
                    }
                }
                Console.WriteLine("Successfully Uploaded Students Score");
                Console.WriteLine("Querying all documents");
                await QueryAllDocuments(db, collectionName);

                QueryLowestScore(db, collectionName);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception \n\n");
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task<int> QueryPersonDetails(IMongoDatabase db, string name, List<StudentScore> studentCollection )
        {

            //string key = "name";
            //string value = name;
            //var collection = db.GetCollection<StudentScore>(dbcollection);
            //var filter = new FilterDefinitionBuilder<StudentScore>().Eq(key, value);
            //var result = await collection.Find(filter).ToListAsync();
            var result = studentCollection;
            var count = result.Count;
            Console.WriteLine("Total Count of Collection after lowscore removal {0} ", count);
            string personName = "Tamika Schildgen";
            var findPerson = studentCollection.Where(c => c._id==137).ToList();    

            Console.WriteLine("Printing Details :");
            foreach (var std in findPerson)
            {
                Console.WriteLine("Id {0}", std._id);
                Console.WriteLine("Name {0}", std.name);
                foreach (var score in std.scores)
                {
                    Console.WriteLine("Type {0}", score.type);
                    Console.WriteLine("Score {0} \n", score.score);
                }
            }

            Console.WriteLine("Collections which has scores zero arrays collections");

            foreach (var studentScore in studentCollection)
            {
                if (studentScore.scores.Count < 1)
                {
                    Console.WriteLine("List ID {0} has zero count ", studentScore._id);
                }
            }


            Console.WriteLine("Aggreate Framework Group By Clause");


            return 1;

        }



        public static async void QueryLowestScore(IMongoDatabase db, string dbcollection ="restaurant")
        {
            var collection = db.GetCollection<StudentScore>(dbcollection);
            var studentcollection = collection.AsQueryable().Where(c => c._id > 0)
               .Select(d => new StudentScore()
               {
                   _id = d._id,
                   name = d.name,
                   scores = d.scores

               }).ToList();

            Console.WriteLine("Getting Low Score Collection");
            var lowScoreCollection =    await QueryPersonLowestHomeWork(db,dbcollection);

            await QueryPersonDetails(db, "", lowScoreCollection);

            var aggStudents = new List<StudentScore>();
            foreach (var low in lowScoreCollection)
            {
                var avgScore = low.scores.GroupBy(c => c.type)
                                .Select(s => new
                                {
                                    key = s.Key,
                                    avgValue = s.Average(l => l.score)
                                }).FirstOrDefault();

                aggStudents.Add(new StudentScore()
                {
                    _id = low._id,
                    name = low.name,
                    scores = new List<Score>()
                    {
                        new Score()
                        {
                            score = avgScore.avgValue,
                            type = avgScore.key
                        }
                    }
                });
            }

            var rootClass = new List<rootresult>();
            foreach (var avgS in aggStudents)
            {
                rootClass.Add(new rootresult()
                {
                    score = avgS.scores.FirstOrDefault().score,
                    _id = avgS._id
                });
            }

            Console.WriteLine("TOtal Count {0} ", rootClass.Count);
            var agglist = rootClass.OrderByDescending(c => c.score).ToList();
            var firstList = agglist.ToList().Take(1);



        }

        public static async Task<List<StudentScore>>  QueryPersonLowestHomeWork(IMongoDatabase db, string dbcollection = "restaurant")
        {
            var collection = db.GetCollection<StudentScore>(dbcollection);
            var lowscorecollection = new List<StudentScore>();
           
            
            var newstudentcollection = db.GetCollection<StudentScore>(dbcollection);
            var count = newstudentcollection.AsQueryable().ToList();

            var studentcollection = collection.AsQueryable();

            foreach (var scorelist in studentcollection)
            {
                if (scorelist._id == 137)
                {
                    var x = 1;
                }
                var newscorelist = new List<Score>();
                var takescore = scorelist.scores.Where(w => w.type == "homework")
                    .GroupBy(c => c.type)
                                         .Select(m => new Score()
                                         {
                                             type = "homework",
                                             score = m.Min(d => d.score)

                                         }).FirstOrDefault();

                foreach (var score in scorelist.scores)
                {
                    if (score.type == takescore.type && score.score == takescore.score)
                    {
                        //do nothing with this score and exclude from the new list.
                    }
                    else
                    {
                        //add to the list of new scores and add to new collection;
                        newscorelist.Add(new Score()
                        {
                            score = score.score,
                            type = score.type
                        });
                    }
                }

                lowscorecollection.Add(new StudentScore()
                {
                    _id = scorelist._id,
                    name = scorelist.name,
                    scores = newscorelist,

                });

                ////remove loweset value from collection;
                //var builder = Builders<StudentScore>.Filter;
                //var filter = builder.Eq("_id", scorelist._id) & builder.Eq("scores.type", "homework") & builder.Eq("scores.score", takescore.score);
                //var result = await newstudentcollection.DeleteOneAsync(filter);



            }

            //lowscorecollection = new List<StudentScore>();
            //lowscorecollection = await newstudentcollection.AsQueryable().ToListAsync();

            return lowscorecollection;
        }


        #endregion

    }
}
