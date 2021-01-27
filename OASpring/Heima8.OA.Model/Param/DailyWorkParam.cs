using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.Model.Param
{
    public class DailyWorkParam : BaseParam
    {
        public string SchWorkName { get; set; }
        public string SchWorkContent { get; set; }
        public int SchSysDeptId { get; set; }
        public int SchUserInfoId { get; set; }
        public string SchRemark { get; set; }

    }
}
