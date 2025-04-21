using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class ContractServicesTbl
    {
        [Key]
        public int Contract_Service_ID { get; set; }
        public string Contract_Service_Name { get; set; }
        public string Contract_Service_Description { get; set; }
        [ForeignKey ("MaintinanceContractsTbl")]
        public int Maintinance_Contract_ID { get; set; }

        public virtual MaintinanceContractsTbl MaintinanceContractsTbl { get; set; }
    }
}
