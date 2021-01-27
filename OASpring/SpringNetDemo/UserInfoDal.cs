using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    public class UserInfoDal : IUserInfoDal
    {
        public UserInfoDal(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;set;
        }

        public void Show()
        {
            Console.WriteLine("月娇乐手 by 老牛" + Name);
        }
    }
}
