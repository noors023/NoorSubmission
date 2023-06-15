using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoorSubmission.Models;

namespace NoorSubmission.Controllers
{
    public class ReadMainFormController : Controller
    {
        public IActionResult Index()
        {    //opening connection 
            using (var dbContext = new AppDbContext())
            {
              List<MainFormModel> persons = dbContext.Forms.ToList();
                return View(persons);
            } 
        }


        public IActionResult Delete()
        {
            //opening connection 
            using (var dbContext2 = new AppDbContext())
            {
                    var forms = dbContext2.Forms.ToList();
                    foreach (var form in forms)
                    {
                    dbContext2.Forms.Remove(form);
                    }
                //reset id of the table to start from 1
                dbContext2.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Forms', RESEED, 1);");
                dbContext2.SaveChanges();
                }
            
            //returning empty model with updated table
            var model = new List<MainFormModel>();
            return View("Index", model);
        }
    }
}
