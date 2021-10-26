using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data.Impl
{
    public class AdultService : IAdultService

    {
        private FileContext _fileContext;
        private IList<Adult> _adults;

        public AdultService(FileContext fileContext)
        {
            _fileContext = fileContext;
            _adults = _fileContext.Adults;
        }

        public void SaveChanges()
        {
            _fileContext.SaveChanges();
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> tmp = new List<Adult>(_adults);
            return tmp;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            adult.Id = _adults.Max(a => a.Id) + 1;
            _adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task<Adult> RemoveAdultAsync(int adultId)
        {
            Adult toRemove = _adults.First(a => a.Id == adultId);
            _adults.Remove(toRemove);
            SaveChanges();
            return toRemove;
        }
    }
}