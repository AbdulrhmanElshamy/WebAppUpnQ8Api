using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class ContractConditionsTbl
    {
        [Key]
        public int Contract_Condition_ID { get; set; }
        public string Contract_Condition_Name { get; set; }
        public string Contract_Condition_Description { get; set; }
        [ForeignKey ("MaintinanceContractsTbl")]
        public int Maintinance_Contract_ID { get; set; }

        public virtual MaintinanceContractsTbl MaintinanceContractsTbl { get; set; }
    }
}
