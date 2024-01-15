using System.Diagnostics;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelRequest.Data;
using TravelRequest.Models;
using TravelRequest.Models.Repository;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace TravelRequest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Create(string EmployeeEmail, string Name, int EmpID, List<string> TravelLocation, 
            string checkInDate, string checkOutDate, int numberOfNights, bool travellingWithOthers, string TravellingWithWho, string Budget, string ReasonForTravel, List<string> WhichCampaign, string ApprovedByWho, bool RentalCar)
        {
            var Model = _context.TsiTravelModels;
            Guid guid = Guid.NewGuid();
            Model.Add(
                     new TsiTravelModel
                     {
                         EmployeeEmail = EmployeeEmail,
                         Uid = guid,
                         Name = Name,
                         EmployeeId = EmpID,
                         TravelLocation = TravelLocation,
                         CheckInDate = checkInDate,
                         CheckOutDate = checkOutDate,
                         NumberOfNights = numberOfNights,
                         TravellingWithOthers = travellingWithOthers,
                         TravellingWithWho = TravellingWithWho,
                         Budget = Budget,
                         ReasonForTravel = ReasonForTravel,
                         WhichCampaign = WhichCampaign,
                         ApprovedByWho = ApprovedByWho,
                         RentalCar = RentalCar
                     }
                ); ;

            _context.SaveChanges();
            await SendEmail(EmployeeEmail, Name, EmpID, TravelLocation, checkInDate, checkOutDate, numberOfNights, travellingWithOthers, TravellingWithWho, Budget, ReasonForTravel, WhichCampaign, ApprovedByWho, RentalCar);
            return RedirectToAction("Index", "Home");
        }
        public async Task SendEmail(string EmployeeEmail, string Name, int EmpID, List<string> TravelLocation, string checkInDate, string checkOutDate, int numberOfNights, bool travellingWithOthers, string TravellingWithWho, string Budget, string ReasonForTravel, List<string> WhichCampaign, string ApprovedByWho, bool RentalCar)
        {
            var adminEmail = "ryn.franco@trisourcebpo.com"; //WATCH OUT
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("portal@trisourcebpo.com", "TriSource2023$"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage()
            {
                From = new MailAddress("portal@trisourcebpo.com"),
                Subject = "Form Submitted Notification",
                Body = $"A form has been submitted with the following details:n\n" +
                       $"Employee's Email: {EmployeeEmail}\n" +
                       $"Name:{Name}\n" +
                       $"Employee ID: {EmpID}" +
                       $"Travel Location: {TravelLocation}\n" +
                       $"Check-in Date: {checkInDate}\n" +
                       $"Check-out Date: {checkOutDate}\n" +
                       $"Number of nights: {numberOfNights}\n" +
                       $"Travelling With Others: {travellingWithOthers}\n" +
                       $"Travelling with Who: {TravellingWithWho}\n" +
                       $"Budget for this trip: {Budget}\n" +
                       $"Reason for travel: {ReasonForTravel}\n" +
                       $"Which Campaign: {WhichCampaign}\n" +
                       $"Approved by who: {ApprovedByWho}\n" +
                       $"Rental car: {RentalCar}",
                IsBodyHtml = false
            };

            mailMessage.To.Add(adminEmail);
            mailMessage.To.Add(EmployeeEmail);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error sending Email: {ex.Message}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
