using Microsoft.EntityFrameworkCore;

namespace NoorSubmission.Models
{
    public class MainFormModel
    { 
        public int MainFormModelId { get; set; }
        public String? Fname { get; set; }
        public String? Lname { get; set; }
        public String? Nationality { get; set; }

        public String? Age { get; set; }




    }
public enum NationalitiesList
{
        Kuwait,
        Lebanon,
        Egypt,
        SpaceToon
}
    

}
