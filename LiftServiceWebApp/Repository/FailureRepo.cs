using LiftServiceWebApp.Data;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Repository
{
    public class FailureRepo : BaseRepository<Failure, Guid>
    {
        public FailureRepo(MyContext context) : base(context)
        {

        }
        public IQueryable<Failure> GetByTechnicianId(string id)
        {
            return Table.Where(x => x.TechnicianId == id && (x.FailureState == FailureStates.Yonlendirildi || x.FailureState == FailureStates.KabulEdildi));
        }
        public IQueryable<Failure> GetStatus(FailureStates status)
        {
            return Table.Where(x => x.FailureState == status);
        }
        public IQueryable<Failure> GetNotAssigned()
        {
            return Table.Where(x => x.TechnicianId == null);
        }
        public IQueryable<Failure> GetAssigned()
        {
            return Table.Where(x => x.TechnicianId != null);
        }
    }
}