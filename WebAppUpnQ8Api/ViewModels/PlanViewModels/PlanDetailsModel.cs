using System.Diagnostics.CodeAnalysis;
using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.ViewModels.PlanViewModels
{
    public class PlanDetailsModel
    {
        public int Plan_ID { get; set; }
        public string Plan_Title { get; set; }
        public string Plan_Description { get; set; }
        public Nullable<double> Price_6m { get; set; }
        public Nullable<double> Price_1y { get; set; }
        public Nullable<double> Price_2y { get; set; }
        public Nullable<double> Price_1m { get; set; }

        public string Plan_Title_Ar { get; set; }
        public string Plan_Description_Ar { get; set; }
        [AllowNull]
        public List<PlanContentModel> PlanContentModels { get; set; }
        //[AllowNull]
        //public List<PlanContentsTbl> planContents { get; set; }
    }
}
