using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUserInfoDal userInfoDal = new UserInfoDal();
            //userInfoDal.Show();

            //下面走一个容器 创建UserInfoDal

            //第一步 初始化容器
            IApplicationContext ctx = ContextRegistry.GetContext();


            //IUserInfoDal dal = ctx.GetObject("UserInfoDal") as IUserInfoDal;
            //dal.Show();

            IUserInfoDal dal1 = ctx.GetObject("UserInfoDal1") as IUserInfoDal;
            dal1.Show();

            //UserInfoService userInfoService = ctx.GetObject("UserInfoService") as UserInfoService;
            //userInfoService.Show();

            Console.ReadKey();
        }
    }
}
