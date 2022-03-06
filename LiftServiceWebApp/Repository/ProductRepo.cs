using LiftServiceWebApp.Data;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Repository.Abstracts;
using System;

namespace LiftServiceWebApp.Repository
{
    public class ProductRepo : BaseRepository<Product, Guid>
    {
        public ProductRepo(MyContext context) : base(context)
        {

        }
    }
}
