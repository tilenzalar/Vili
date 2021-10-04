using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VilicappAPI.ModelsUI;

namespace VilicappAPI.Interfaces
{
    public interface IForkLiftService
    {
        List<ForkLiftUI> GetAllForkLifts();
        List<ForkLiftUI> GetNotRentedForkLifts();
        List<ForkLiftRentUI> GetAllForkLiftRents();
        bool AddForkLift(ForkLiftUI forkLift);
        bool DeleteForkLift(int forkLiftId);
        ForkLiftRentUI GetForkLiftRent(int forkLiftId);
        int AddForkLiftRent(ForkLiftRentUI forkLiftRent);
        bool FinishForkLiftRent(int forkLiftRentId);

    }
}
