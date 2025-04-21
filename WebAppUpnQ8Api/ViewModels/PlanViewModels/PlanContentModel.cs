using System.Diagnostics.CodeAnalysis;

namespace WebAppUpnQ8Api.ViewModels.PlanViewModels
{
    public class PlanContentModel
    {
        public int Plan_Content_ID { get; set; }
        public int Content_ID { get; set; }
        public Nullable<int> Plan_ID { get; set; }
        [AllowNull]
        public string Content_Value { get; set; }
        [AllowNull]
        public string Content_Name { get; set; }
        [AllowNull]
        public string Content_Value_Ar { get; set; }
        [AllowNull]
        public string Content_Name_Ar { get; set; }
    }
}
