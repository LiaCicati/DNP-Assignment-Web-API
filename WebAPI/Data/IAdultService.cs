using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IAdultService
    {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);

        void RemoveAdult(int adultId);
    }
}