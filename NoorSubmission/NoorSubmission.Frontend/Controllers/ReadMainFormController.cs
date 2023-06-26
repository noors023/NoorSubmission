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

                    return View(content);
                }
                else
                {
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
                {
                    var contentinserted = await response.Content.ReadAsAsync<List<MainFormDto>>();

                    return View("Index", contentinserted);
                }
                else
                {
                    return View("Error");
                }
            }

        }

        public async Task<IActionResult> GetFormReport()
        {

            using var httpClient = new HttpClient();
            {
                var url = "http://localhost:5183/api/Submisson/download";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    Stream stream = await response.Content.ReadAsStreamAsync();

                    string fileName = "report.pdf";
                    string contentType = "application/pdf";

                    return File(stream, contentType, fileName);

                }
                else
                {
                    return NotFound();

                }

            }

        }




    }
}
