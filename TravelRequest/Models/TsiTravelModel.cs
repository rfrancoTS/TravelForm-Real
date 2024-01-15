using System.ComponentModel.DataAnnotations;

namespace TravelRequest.Models
{
    public class TsiTravelModel
    {

         public int Id { get; set; }
        public Guid? Uid { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? Name { get; set; }
        public int? EmployeeId { get; set; }           

        //this should become a List<> when the parameter is set.
        public List<string>? TravelLocation { get; set; }
       
        
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }

        //this field will be removed/refactored later
        public int? NumberOfNights { get; set; }
        public bool? TravellingWithOthers { get; set; }

        //this field will removed/refactored later
        public string? TravellingWithWho { get; set; }
        public string? Budget { get; set; }   
        public string? ReasonForTravel { get; set; }

        //this should become a List<> when the parameter is set.
        public List<string>? WhichCampaign { get; set; }

        public string? ApprovedByWho { get; set; }
        public bool? RentalCar { get; set; }
      
     

    }
}
