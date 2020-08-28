using Peak.Discoun.Context;
using Peak.Discoun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discoun.Repository
{
    public class PackRepository : IPackRepository
    {
        private readonly AppDbContext context;

        public PackRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Pack Add(Pack pack)
        {
          
            context.Pack.Add(pack);
            context.SaveChanges();
            return pack;
        }
    

        public Pack Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pack> GetAllPack()
        {
            throw new NotImplementedException();
        }

        public Pack GetPackById(int Id)
        {
            throw new NotImplementedException();
        }

        public Pack Update(Pack packChanges)
        {
            throw new NotImplementedException();
        }
    }
}
