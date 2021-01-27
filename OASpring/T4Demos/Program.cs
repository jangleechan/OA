using Heima8.OA.BLL;
using Heima8.OA.IBLL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            IDailyWorkService service = new DailyWorkService();
            DailyWork dw = new DailyWork() { Id=1,WorkName = "aaaa" };
            service.Add(dw);

        }
    }
}
