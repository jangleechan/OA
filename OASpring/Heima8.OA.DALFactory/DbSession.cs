using Heima8.OA.EFDAL;
using Heima8.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.DALFactory
{
    public partial class DbSession:IDbSession
    {
        #region 简单工厂或这抽象工厂部分
        //public IUserInfoDal UserInfoDal
        //{
        //    get { return StaticDalFactory.GetUserInfoDal(); }
        //}
        //public IOrderInfoDal OrderInfoDal
        //{
        //    get { return StaticDalFactory.GetOrderInfoDal(); }
        //}

       
        #endregion
        /// <summary>
        /// 拿到当前的EF的上下文
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
