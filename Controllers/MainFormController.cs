using Microsoft.AspNetCore.Mvc;
using NoorSubmission.Models;

namespace NoorSubmission.Controllers
{
    public class MainFormController : Controller
    {

        //GET: MainForm/MainformIndex
        
        public IActionResult MainFormIndex(IFormCollection FormInputs)
        { 
           if (FormInputs["Fname1"].Count > 0 && !FormInputs["Fname1"].Equals("") && !FormInputs["Nationality1"].Equals("Select Nationality") && !FormInputs["Nationality1"].Equals(""))
            {
                //Write into DB 
                MainFormModel Form = new MainFormModel();
                Form.Fname = FormInputs["Fname1"];
                Form.Lname = FormInputs["Lname1"];
                Form.Age = FormInputs["Age1"];
                Form.Nationality = FormInputs["Nationality1"];

                using (var context = new AppDbContext())
                {
                    context.Forms.Add(Form);
                    context.SaveChanges();
                    Console.WriteLine("new data added :)");
                }
                Console.WriteLine(Form.Fname + "-" + Form.Lname + "-" + Form.Age + "-" + Form.Nationality);


            } 

            return View();
        }
 


       


    }
}
