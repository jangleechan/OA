using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.EFDAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            //一次请求公用一个实例。上下文都可以做到切换
            //return new ContextModelContainer();
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if(db == null)
            {
                db = new ContextModelContainer();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }
}
