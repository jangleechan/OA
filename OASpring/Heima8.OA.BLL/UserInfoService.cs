using Heima8.OA.IBLL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.BLL
{
    public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {

        //模块内高内聚。模块间低耦合

        //变化点：1、跨数据库。有mySql,sqlServer  2、

        //稍微高级点开发人员
        //private IUserInfoDal userInfoDal = StaticDalFactory.GetUserInfoDal();
        //DbSession dbSession = new DbSession();
        //IDbSession dbSession = new DbSession();
        //private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();

        //更高级:IoC、DI依赖注入的方式。 Spring.Net
        //public UserInfo Add(UserInfo userInfo)//UnitWork单元工作模式
        //{
        //    //让一个菜鸟到另一个一般开发人员
        //    // 依赖接口编程
        //    //return dbSession.UserInfoDal.Add(userInfo);
        //    dbSession.UserInfoDal.Add(userInfo);
        //    dbSession.UserInfoDal.Add(new UserInfo());
        //    dbSession.OrderInfoDal.Delete(new OrderInfo());
        //    dbSession.OrderInfoDal.Update(new OrderInfo());
        //    //return userInfoDal.Add(userInfo);
        //    //数据提交的权力从数据库访问层提到了业务逻辑层

        //    if(dbSession.SaveChanges() >0)
        //    {
        //        return userInfo;
        //    }

        //}

        //public UserInfoService(IDbSession dbSession):base(dbSession)
        //{
        //    //this.DbSession = dbSession;
        //}

        //public override void SetCurrentDal()
        //{
        //    CurrentDal = this.DbSession.UserInfoDal;
        //}

        public IQueryable<UserInfo> LoadPageData(Model.Param.UserQueryParam userQueryParam)
        {
            short normalFlag = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;
            var temp = DbSession.UserInfoDal.GetEntities(u => u.DelFlag == normalFlag);

            //过滤
            if (!string.IsNullOrEmpty(userQueryParam.SchName))
            {
                temp = temp.Where(u => u.UName.Contains(userQueryParam.SchName)).AsQueryable();
            }

            if(!string.IsNullOrEmpty(userQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(userQueryParam.SchRemark)).AsQueryable();
            }

            userQueryParam.Total = temp.Count();

            //分页
            return temp.OrderBy(u => u.Id)
                .Skip(userQueryParam.PageSize * (userQueryParam.PageIndex - 1))
                .Take(userQueryParam.PageSize).AsQueryable();
        }
    }
}
