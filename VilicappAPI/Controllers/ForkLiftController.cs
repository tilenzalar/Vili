using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilicappAPI.Interfaces;
using VilicappAPI.Models;
using VilicappAPI.ModelsUI;

namespace VilicappAPI.Controllers
{
    public class ForkLiftController : Controller
    {
        private readonly IForkLiftService _forkLiftService;
        public ForkLiftController(IForkLiftService forkLiftService)
        {
            _forkLiftService = forkLiftService;
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetAllForkLifts")]
        public ActionResult<List<ForkLiftUI>> GetAllForkLifts()
        {
            return _forkLiftService.GetAllForkLifts();
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetNotRentedForkLifts")]
        public ActionResult<List<ForkLiftUI>> GetNotRentedForkLifts()
        {
            return _forkLiftService.GetNotRentedForkLifts();
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetAllForkLiftRents")]
        public ActionResult<List<ForkLiftRentUI>> GetAllForkLiftRents()
        {
            return _forkLiftService.GetAllForkLiftRents();
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpPost("AddForkLift")]
        public ActionResult<bool> AddForkLift([FromBody] ForkLiftUI forkLift)
        {
            return _forkLiftService.AddForkLift(forkLift);
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpDelete("DeleteForkLift")]
        public ActionResult<bool> DeleteForkLift(int forkLiftId)
        {
            return _forkLiftService.DeleteForkLift(forkLiftId);
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetForkLiftRent")]
        public ActionResult<ForkLiftRentUI> GetForkLiftRent(int forkLiftId)
        {
            return _forkLiftService.GetForkLiftRent(forkLiftId);
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpPost("AddForkLiftRent")]
        public ActionResult<int> AddForkLiftRent([FromBody] ForkLiftRentUI forkLiftRent)
        {
            return _forkLiftService.AddForkLiftRent(forkLiftRent);
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpDelete("FinishForkLiftRent")]
        public ActionResult<bool> FinishForkLiftRent(int forkLiftRentId)
        {
            return _forkLiftService.FinishForkLiftRent(forkLiftRentId);
        }
    }
}
