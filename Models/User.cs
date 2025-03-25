using System.Data;
using BSLibrary.Models;

namespace WebApplication1.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }    
        public string Email { get; set; }   
        public string PasswordHash { get; set; }  
    }
}
