using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.IDAL
{
    public  interface IBaseDal<T> where T:class, new()
    {
 

        // 单元测试
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetPageEntites<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda,
        
                                                                Expression<Func<T, S>> orderByLambda, bool isAsc);
        T GetEntityById(int id);

        List<T> GetAllEntities();

        #region cud
        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        bool Delete(int id);

        int DeleteListByLogical(List<int> ids);
        #endregion


    }
}
