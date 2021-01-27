using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.EFDAL
{
    /// <summary>
    /// 职责:封装所有Dal的公共crud
    /// </summary>
    public class BaseDal<T> where T : class, new()
    {
        /// <summary>
        /// 职责：封装所有的Dal的公共的crud方法
        /// 类的职责一定要单一
        /// </summary>
        //ContextModelContainer db = new ContextModelContainer();
        public DbContext Db 
        {
            get { return  DbContextFactory.GetCurrentDbContext(); }
        }

        #region 查询
        public T GetEntityById(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public List<T> GetAllEntities()
        {
            return Db.Set<T>().ToList();
        }
        // 单元测试
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }
        #endregion

        #region cud
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }

        public bool Delete(T entity)
        {
            Db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }

        public bool Delete(int id)
        {
            var entity = Db.Set<T>().Find(id);
            Db.Set<T>().Remove(entity);
            return true;
        }

        public int DeleteListByLogical(List<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = Db.Set<T>().Find(id);
                Db.Entry(entity).Property("DelFlag").CurrentValue = (short)Heima8.OA.Model.Enum.DelFlagEnum.Deleted;
                Db.Entry(entity).Property("DelFlag").IsModified = true;
            }
            return ids.Count;
            
        }
        #endregion

        public IQueryable<T> GetPageEntites<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda,
                                                            Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();

            if (isAsc)
            {
                var temp = Db.Set<T>().Where(whereLambda).OrderBy<T, S>(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = Db.Set<T>().Where(whereLambda).OrderBy<T, S>(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
                return temp;
            }


        }

    }
}

