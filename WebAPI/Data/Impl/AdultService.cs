using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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

        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(_adults);
            return tmp;
        }

        public void AddAdult(Adult adult)
        {
            adult.Id = _adults.Max(a => a.Id) + 1;
            _adults.Add(adult);
            SaveChanges();
        }

        public void RemoveAdult(int adultId)
        {
            Adult toRemove = _adults.First(a => a.Id == adultId);
            _adults.Remove(toRemove);
            SaveChanges();
        }
    }
}