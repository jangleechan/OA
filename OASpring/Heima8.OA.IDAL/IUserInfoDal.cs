﻿using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.IDAL
{
    public partial interface IUserInfoDal:IBaseDal<UserInfo>
    {
        IQueryable<UserInfo> LoadPageData(Model.Param.UserQueryParam userQueryParam);
    }
}
