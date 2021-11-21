using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IAdultRepository
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);

        Task<Adult> RemoveAdultAsync(int adultId);
    }
}