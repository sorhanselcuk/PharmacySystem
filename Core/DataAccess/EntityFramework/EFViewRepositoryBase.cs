using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EFViewRepositoryBase<TViewEntity, TContext> : IViewRepository<TViewEntity>
        where TViewEntity : class, IView, new()
        where TContext : DbContext, new()
    {
        public TViewEntity Get(Expression<Func<TViewEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TViewEntity>().SingleOrDefault(filter);
            }
        }

        public List<TViewEntity> GetAll(Expression<Func<TViewEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TViewEntity>().ToList()
                    : context.Set<TViewEntity>().Where(filter).ToList();
            }
        }
    }
}
