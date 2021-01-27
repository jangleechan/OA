﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Heima8.OA.EFDAL;
using Heima8.OA.Model;
using System.Linq;

namespace Heima8.OA.UnitTest
{
    [TestClass]
    public class UserInfoDalTest
    {
        [TestMethod]
        public void TestGetUsers()
        {
            //单元测试是没用的，浪费开发时间而已?
            //1、节省改bug的时间

            //2、对项目非常有自信

            //3、但原测试也是一种设计(写单元测试的时候促进对方法进行再思考)

            //4、它也是一种项目管理的手段。 TDD:测试驱动开发

      

            // 测试 获取数据的方法。
            UserInfoDal dal = new UserInfoDal();

            // 单元测试必须自己处理数据，不能依赖第三方数据，如果依赖数据那么先自己创建数据，然后用完之后再清除数据。

            //创建测试的数据
            for (var i = 0; i < 10; i++)
            {
                dal.Add(new UserInfo()
                {
                    UName = i + "sssss"
                });
            }
            IQueryable<UserInfo> temp = dal.GetEntities(u=>u.UName.Contains("ss"));

            //断言
            Assert.AreEqual(true, temp.Count() >= 10);
        }
    }
}
