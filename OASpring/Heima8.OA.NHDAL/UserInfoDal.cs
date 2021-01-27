using Heima8.OA.IDAL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heima8.OA.Model.Param;

namespace Heima8.OA.NHDAL
{
    public class UserInfoDal : IUserInfoDal
    {
        public OA.Model.UserInfo Add(OA.Model.UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OA.Model.UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteListByLogical(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public List<OA.Model.UserInfo> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public IQueryable<OA.Model.UserInfo> GetEntities(System.Linq.Expressions.Expression<Func<OA.Model.UserInfo, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public OA.Model.UserInfo GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OA.Model.UserInfo> GetPageEntites<S>(int pageSize, int pageIndex, out int total, System.Linq.Expressions.Expression<Func<OA.Model.UserInfo, bool>> whereLambda, System.Linq.Expressions.Expression<Func<OA.Model.UserInfo, S>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> LoadPageData(UserQueryParam userQueryParam)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
