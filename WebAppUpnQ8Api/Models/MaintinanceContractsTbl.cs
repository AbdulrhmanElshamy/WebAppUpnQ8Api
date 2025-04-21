using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class MaintinanceContractsTbl
    {
        [Key]
        public int Maintinance_Contract_ID { get; set; }
        public string Maintinance_Contract_Title_Ar { get; set; }
        public string Maintinance_Contract_Title_Eng { get; set; }
        public Nullable<int> Maintinance_Contract_Duration { get; set; }
        public Nullable<int> Duration_By_Month { get; set; }

        public virtual ICollection<ContractConditionsTbl> ContractConditionsTbls { get; set; }
        public virtual ICollection<ContractServicesTbl> ContractServicesTbls { get; set; }
        public virtual ICollection<MaintinanceRequestsTbl> MaintinanceRequestsTbls { get; set; }
    }
}
