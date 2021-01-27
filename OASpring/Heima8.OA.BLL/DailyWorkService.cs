using Heima8.OA.IBLL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.BLL
{
    public partial class DailyWorkService:BaseService<DailyWork>,IDailyWorkService
    {

        public IQueryable<DailyWork> LoadPageData(Model.Param.DailyWorkParam dailyWorkQueryParam)
        {
            short normalFlag = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;
            var temp = DbSession.DailyWorkDal.GetEntities(u => u.DelFlag == normalFlag);

            //过滤问题描述
            if (!string.IsNullOrEmpty(dailyWorkQueryParam.SchWorkName))
            {
                temp = temp.Where(u => u.WorkName.Contains(dailyWorkQueryParam.SchWorkName)).AsQueryable();
            }
            //过滤处理方法
            if (!string.IsNullOrEmpty(dailyWorkQueryParam.SchWorkContent))
            {
                temp = temp.Where(u => u.WorkContent.Contains(dailyWorkQueryParam.SchWorkContent)).AsQueryable();
            }
            //过滤备注
            if (!string.IsNullOrEmpty(dailyWorkQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(dailyWorkQueryParam.SchRemark)).AsQueryable();
            }

            //过滤科室名称
            if (dailyWorkQueryParam.SchSysDeptId > 0)
            {
                temp = temp.Where(u => u.SysDeptId == dailyWorkQueryParam.SchSysDeptId).AsQueryable();
            }

            if (dailyWorkQueryParam.SchUserInfoId > 0)
            {
                temp = temp.Where(u => u.UserInfoId == dailyWorkQueryParam.SchUserInfoId).AsQueryable();
            }

            dailyWorkQueryParam.Total = temp.Count();

            //分页
            return temp.OrderByDescending(u => u.SubTime)
                .Skip(dailyWorkQueryParam.PageSize * (dailyWorkQueryParam.PageIndex - 1))
                .Take(dailyWorkQueryParam.PageSize).AsQueryable();
        }
    }
}
