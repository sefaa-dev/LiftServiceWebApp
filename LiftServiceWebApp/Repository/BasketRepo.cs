using LiftServiceWebApp.Data;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Repository.Abstracts;
using System;

namespace LiftServiceWebApp.Repository
{
    public class BasketRepo : BaseRepository<Basket, Guid>
    {
        public BasketRepo(MyContext context) : base(context)
        {

        }
    }
}
