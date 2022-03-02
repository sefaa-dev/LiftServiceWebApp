﻿using LiftServiceWebApp.Models.Abstracts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LiftServiceWebApp.Repository.Abstracts
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        TEntity GetById(TKey id);
        TKey Insert(TEntity entity, bool isSaveLater = false);
        int Update(TEntity entity, bool isSaveLater = false);

        int Delete(TKey id, bool isSaveLater = false);
        int Save();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
    }
}