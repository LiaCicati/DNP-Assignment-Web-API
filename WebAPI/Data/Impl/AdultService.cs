using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data.Impl
{
    public class AdultService : IAdultService

    {
        private AdultsDbContext _ctx;

        public AdultService(AdultsDbContext context)
        {
            this._ctx = context;
        }


        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return await _ctx.Adults.Include(adult => adult.JobTitle).ToListAsync();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            EntityEntry<Adult> newlyAdded = await _ctx.Adults.AddAsync(adult);
            await _ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<Adult> RemoveAdultAsync(int adultId)
        {
            Adult toDelete = await _ctx.Adults.FirstOrDefaultAsync(t => t.Id == adultId);
            if (toDelete != null)
            {
                _ctx.Adults.Remove(toDelete);
                await _ctx.SaveChangesAsync();
            }

            return toDelete;
        }
    }
}