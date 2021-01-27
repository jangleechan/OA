using Heima8.OA.IDAL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Heima8.OA.Model.Param;

namespace Heima8.OA.EFDAL
{
    public partial class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
    {


        //    ContextModelContainer db = new ContextModelContainer();

        //    #region 查询
        //    public UserInfo GetUserInfoById(int id)
        //    {
        //        return db.UserInfo.Find(id);
        //    }

        //    public List<UserInfo> GetAllUserInfos(int id)
        //    {
        //        return db.UserInfo.ToList();
        //    }
        //    // 单元测试
        //    public IQueryable<UserInfo> GetUsers(Expression<Func<UserInfo, bool>> whereLambda)
        //    {
        //        return db.UserInfo.Where(whereLambda).AsQueryable();
        //    }
        //    #endregion

        //    #region cud
        //    public UserInfo Add(UserInfo userInfo)
        //    {
        //        db.UserInfo.Add(userInfo);
        //        db.SaveChanges();
        //        return userInfo;
        //    }

        //    public bool Update(UserInfo userInfo)
        //    {
        //        db.Entry(userInfo).State = EntityState.Modified;
        //        return db.SaveChanges() >0;
        //    }

        //    public bool Delete(UserInfo userInfo)
        //    {
        //        db.Entry(userInfo).State = System.Data.Entity.EntityState.Deleted;
        //        return db.SaveChanges() > 0;
        //    }
        //    #endregion

        //    public IQueryable<UserInfo> GetPageUsers<S>(int pageSize, int pageIndex, out int total, Expression<Func<UserInfo, bool>> whereLambda,
        //                                                        Expression<Func<UserInfo, S>> orderByLambda, bool isAsc)
        //    {
        //        total = db.UserInfo.Where(whereLambda).Count();

        //        if (isAsc)
        //        {
        //            var temp = db.UserInfo.Where(whereLambda).OrderBy<UserInfo, S>(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
        //            return temp;
        //        }
        //        else
        //        {
        //            var temp = db.UserInfo.Where(whereLambda).OrderBy<UserInfo, S>(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
        //            return temp;
        //        }


        //    }
        public IQueryable<UserInfo> LoadPageData(UserQueryParam userQueryParam)
        {
            throw new NotImplementedException();
        }
    }
}
