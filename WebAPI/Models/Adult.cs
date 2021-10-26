using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebAPI.Models
{
    public class Adult : Person
    {
        public Job JobTitle { get; set; }
    }
}