using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppUpnQ8Api.Models
{
    public class RefreshTokenTbl
    {
        [Key]
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
