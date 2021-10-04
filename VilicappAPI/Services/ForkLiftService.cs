using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilicappAPI.Interfaces;
using VilicappAPI.Models;
using VilicappAPI.ModelsUI;


namespace VilicappAPI.Services
{
    public class ForkLiftService : IForkLiftService
    {
        private readonly VilicAppDbContext _context;
        public ForkLiftService(VilicAppDbContext context)
        {
            _context = context;
        }

        public bool AddForkLift(ForkLiftUI forkLift)
        {
            var f = new ForkLift
            {
                Name = forkLift.Name,
                Description = forkLift.Description,
                ForkLiftTypeId = forkLift.ForkLiftTypeId,
                InternalNumber = forkLift.InternalNumber,
                IsDeleted = false
            };
            _context.ForkLifts.Add(f);
            _context.SaveChanges();
            return true;
        }

        public int AddForkLiftRent(ForkLiftRentUI forkLiftRent)
        {
            var f = new ForkLiftRent
            {
                Client = forkLiftRent.Client,
                ForkLiftId = forkLiftRent.ForkLiftId,
                StartRent = forkLiftRent.StartRent,
                EndRent = forkLiftRent.EndRent,
                IsFinished = false,
                Lat = forkLiftRent.Lat,
                Lng = forkLiftRent.Lng,
            };
            _context.ForkLiftRents.Add(f);

            var lift = _context.ForkLifts.Where(f => forkLiftRent.ForkLiftId == f.Id).FirstOrDefault();
            lift.ForkLiftTypeId = 2;

            _context.SaveChanges();
            return f.Id;
        }

        public bool DeleteForkLift(int forkLiftId)
        {
            var forklift = _context.ForkLifts.Where(f => f.Id == forkLiftId).FirstOrDefault();
            forklift.IsDeleted = true;
            _context.SaveChanges();
            return true;
        }

        public bool FinishForkLiftRent(int forkLiftRentId)
        {
            var fRent = _context.ForkLiftRents.Where(f => f.Id == forkLiftRentId).FirstOrDefault();
            fRent.IsFinished = true;
            var lift = _context.ForkLifts.Where(f => fRent.ForkLiftId == f.Id).FirstOrDefault();
            lift.ForkLiftTypeId = 1;
            _context.SaveChanges();
            return true;
        }

        public List<ForkLiftRentUI> GetAllForkLiftRents()
        {
            var list = _context.ForkLiftRents.Where(f => !f.IsFinished).Select(f => new ForkLiftRentUI{            
                Id = f.Id,
                Client = f.Client,
                StartRent = f.StartRent,
                EndRent = f.EndRent,
                Lat = f.Lat,
                Lng = f.Lng,
                ForkLiftName = f.ForkLift.Name,
                ForkLiftExtendedName = f.ForkLift.InternalNumber + " - " + f.ForkLift.Name
            }).ToList();

            return list;
        }

        public List<ForkLiftUI> GetAllForkLifts()
        {
            var list = _context.ForkLifts.Where(f => !f.IsDeleted).Select(f => new ForkLiftUI
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                ForkLiftTypeId = f.ForkLiftTypeId,
                ForkLiftTypeName = f.ForkLiftType.Name,
                IsDeleted = f.IsDeleted,
                InternalNumber = f.InternalNumber
            }).ToList();

            return list;
        }

        public ForkLiftRentUI GetForkLiftRent(int forkLiftId)
        {
            var fRent = _context.ForkLiftRents.Where(f => f.ForkLiftId == forkLiftId && !f.IsFinished).Select(f => new ForkLiftRentUI {      
                Id = f.Id,
                Client = f.Client,
                StartRent = f.StartRent,
                EndRent = f.EndRent,
                ForkLiftId = f.ForkLiftId,
                IsFinished = f.IsFinished,
                Lat = f.Lat,
                Lng = f.Lng,
                ForkLiftName = f.ForkLift.Name,
                ForkLiftExtendedName = f.ForkLift.InternalNumber + " - " + f.ForkLift.Name
            }).FirstOrDefault();

            return fRent;
        }

        public List<ForkLiftUI> GetNotRentedForkLifts()
        {
            var list = _context.ForkLifts.Where(f => !f.IsDeleted && !f.ForkLiftRents.Any(flr => !flr.IsFinished)).Select(f => new ForkLiftUI
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                ForkLiftTypeId = f.ForkLiftTypeId,
                ForkLiftTypeName = f.ForkLiftType.Name,
                IsDeleted = f.IsDeleted,
                InternalNumber = f.InternalNumber
            }).ToList();

            return list;
        }
    }
}
