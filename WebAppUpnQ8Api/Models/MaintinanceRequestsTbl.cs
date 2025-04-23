using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class MaintinanceRequestsTbl
    {
        [Key]
        public int Maintinance_Request_ID { get; set; }
        [ForeignKey ("MaintinanceContractsTbl")]
        public int Maintinance_Contract_ID { get; set; }
        [ForeignKey ("CustomersTbl")]
        public string Customer_ID { get; set; }
        public Nullable<bool> Request_Statues { get; set; }

        public virtual ApplicationUser CustomersTbl { get; set; }
        public virtual MaintinanceContractsTbl MaintinanceContractsTbl { get; set; }
    }
}
