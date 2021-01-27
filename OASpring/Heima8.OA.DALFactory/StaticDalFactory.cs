using Heima8.OA.EFDAL;
using Heima8.OA.IDAL;
using Heima8.OA.NHDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.DALFactory
{
    /// <summary>
    /// 由简单工厂转变成了抽象工厂
    /// 抽象工厂  VS  简单工厂
    /// </summary>
    public partial class StaticDalFactory
    {
        public static string assemblyName = 
            System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
        //public static IUserInfoDal GetUserInfoDal()
        //{
            
        //    //return new NHUserInfoDal();
        //    //把上面的new 去掉:希望改一个配置那么创建实例就发生变化,不需要改代码

        //    return Assembly.Load(assemblyName)
        //        .CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;
        //}

        //public static IOrderInfoDal GetOrderInfoDal()
        //{
        //    //return new OrderInfoDal();
        //    return Assembly.Load(assemblyName)
        //        .CreateInstance(assemblyName + ".OrderInfoDal") as IOrderInfoDal;
        //}
    }
}
