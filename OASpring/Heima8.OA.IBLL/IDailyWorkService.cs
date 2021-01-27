using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.IBLL
{
    public partial interface IDailyWorkService:IBaseService<DailyWork>
    {
        IQueryable<DailyWork> LoadPageData(Model.Param.DailyWorkParam dailyWorkQueryParam);
    }
}
