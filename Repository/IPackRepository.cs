using Peak.Discount.Model;
using System.Collections.Generic;

namespace Peak.Discount.Dashboard.Repository
{
    public  interface IPackRepository
    {
        Pack GetPackById(int Id);
        IEnumerable<Pack> GetAllPack();
        Pack Add(Pack pack);
        Pack Update(Pack packChanges);
        Pack Delete(int Id);

    }
}
