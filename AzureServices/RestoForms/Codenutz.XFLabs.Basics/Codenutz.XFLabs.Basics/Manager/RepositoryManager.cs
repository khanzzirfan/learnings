using Codenutz.XFLabs.Basics.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.Manager
{
    public class RepositoryManager
    {
        public static AppRepository<HomeDAO> HomeRepo()
        {
            return new AppRepository<HomeDAO>();
        }
        
    }
}
