using Codenutz.XFLabs.Basics.Contracts;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.DAL
{
    public class BuildVersion : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int versionId { get; set; }

        public bool IsCurrentVersion { get; set; }
    }
}
