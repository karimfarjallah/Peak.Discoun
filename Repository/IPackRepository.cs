using Peak.Discoun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discoun.Repository
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
