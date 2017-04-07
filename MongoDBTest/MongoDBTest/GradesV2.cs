using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDBTest
{
	public class GradeV2Score
	{
		public string type { get; set; }
		public double score { get; set; }
	}

	public class GradeV2Id
    {
        public string oid { get; set; }
    }

    public class GradeV2
    {
		public ObjectId _id { get; set; }
		public int student_id { get; set; }
		public int class_id { get; set; }
		public List<Score> scores { get; set; }
	}


}
