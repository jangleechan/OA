using Heima8.OA.EFDAL;
using Heima8.OA.IBLL;
using Heima8.OA.IDAL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.BLL
{
    public partial class OrderInfoService:BaseService<OrderInfo>,IOrderInfoService
    {
        //public OrderInfo Add(OrderInfo orderInfo)
        //{
        //    IOrderInfoDal orderInfoDal = new OrderInfoDal();
        //    return orderInfoDal.Add(orderInfo);
        //}

        //public OrderInfoService(IDbSession dbSession):base(dbSession)
        //{
        //    //this.DbSession = dbSession;
        //}

        //public override void SetCurrentDal()
        //{
        //    CurrentDal = DbSession.OrderInfoDal;
        //}
    }
}
