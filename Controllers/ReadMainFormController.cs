using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoorSubmission.Models;
using System.Data.Entity;
using System.Net.Http;


namespace NoorSubmission.Controllers
{ 
    public class ReadMainFormController : Controller
    {   
         
        public async Task<IActionResult> Index()
        {
            using var httpClient = new HttpClient();
            {
                var url = "http://localhost:5183/api/Submisson";
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsAsync<List<MainFormDto>>();
                    // Handle the content
                    return View(content);
                }
                else
                {
                    // Handle the error case
                    return View("Error");
                }

            }
           
        }

        public async Task<IActionResult> Delete()
        {
            using var httpClient = new HttpClient();
            {
                var url = "http://localhost:5183/api/Submisson";
                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                { //returning updated list  
                    var contentinserted = await response.Content.ReadAsAsync<List<MainFormDto>>();
                    // Handle the content 
                    return View("Index" , contentinserted);
                }
                else
                {
                    // Handle the error case
                    return View("Error");
                }
            }
            
        }




    }
}
