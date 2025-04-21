using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class EvaluationsTbl
    {
        [Key]
        public int Evaluation_ID { get; set; }
        public string Id { get; set; }
        [ForeignKey ("ProductsTbl")]
        public int Product_ID { get; set; }
        public Nullable<int> Evaluation_Stars { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> Evaluation_Date { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual ProductsTbl ProductsTbl { get; set; }
    }
}
