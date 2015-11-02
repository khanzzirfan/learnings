using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDBTest
{
    public class Grades
    {
        public ObjectId _id { get; set; }
        public int student_id { get; set; }
        public string type { get; set; }
        public double score { get; set; }
    }




    public class Id
    {
        public string oid { get; set; }
    }

    public class RootObjectGrades
    {
        public Id _id { get; set; }
        public int student_id { get; set; }
        public string type { get; set; }
        public double score { get; set; }
    }


}
