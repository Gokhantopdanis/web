using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index() 
        {
            int saat = DateTime.Now.Hour;
            // ViewBag.selamlama = saat > 12 ? "İyi Günler": "Günaydın";
            // ViewBag.UserName = "Sadık";
            
            ViewData["selamlama"] = saat > 12 ? "İyi Günler": "Günaydın";
            //ViewData["UserName"] = "Sadık";

            var UserCount = Repository.Users.Where(i=>i.WillAttend == true).Count();


            var meetingInfo = new MeetingInfo() 
            {
                Id = 1,
                Location = "İstanbul, ABC Kongre Merkezi",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = UserCount
            };
 
            return View(meetingInfo);
        }
    }
}