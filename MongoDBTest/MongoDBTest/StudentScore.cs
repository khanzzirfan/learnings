using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBTest
{
    public class Score
    {
        public string type { get; set; }
        public double score { get; set; }
    }

    public class StudentScore
    {
        public int _id { get; set; }
        public string name { get; set; }
        public List<Score> scores { get; set; }
    }

    public class rootresult
    {
        public int _id { get; set; }
        public double score { get; set; }
    }
}
