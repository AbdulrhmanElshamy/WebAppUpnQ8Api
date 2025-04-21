using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class DurationsTbl
    {
        [Key]
        public int Duration_ID { get; set; }
        public Nullable<double> Duration_Value { get; set; }
    }
}
