using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data.Impl
{
    public class AdultRepository :IAdultRepository
    {
        private AdultsDbContext _ctx;
        
        public AdultRepository(AdultsDbContext context)
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