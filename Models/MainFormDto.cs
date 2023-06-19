using Microsoft.EntityFrameworkCore;
 
namespace NoorSubmission.Models
{ 
    public class MainFormDto
    { 
        public int MainFormDtoId { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Nationality { get; set; }
        public string? Age { get; set; }
    }
}
